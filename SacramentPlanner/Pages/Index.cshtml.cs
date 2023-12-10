using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SacramentPlanner.Models;
using static System.Reflection.Metadata.BlobBuilder;

namespace SacramentPlanner.Pages
{
    public class IndexModel : PageModel
    {
        private readonly SacramentPlanner.Data.SacramentPlannerContext _context;

        public IndexModel(SacramentPlanner.Data.SacramentPlannerContext context)
        {
            _context = context;
        }

        public IList<Meeting> Meeting { get;set; } = default!;

		// For searching records by speaker name
		[BindProperty(SupportsGet = true)]
        public string? NameSearchString { get; set; }


		// For searching records by speaker name
		[BindProperty(SupportsGet = true)]
		public string? TopicSearchString { get; set; }


		// For sorting records by date or ward name
		public SelectList? SortOptions { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? SortOption { get; set; }


		public async Task OnGetAsync()
		{
			IQueryable<Meeting> meetingsQuery = _context.Meeting;

			SortOptions = new SelectList(new List<SelectListItem>
			{
				new SelectListItem { Text = "Date", Value = "Date" },
				new SelectListItem { Text = "Ward", Value = "Ward" }
			}, "Value", "Text");

			// Add sort functionality
			if (SortOption == "Date")
			{
				meetingsQuery = meetingsQuery.OrderBy(x => x.Date);
			}
			else if (SortOption == "Ward")
			{
				meetingsQuery = meetingsQuery.OrderBy(x => x.WardName);
			}

			// Fetch all meetings without including TalksList initially
			var allMeetings = await meetingsQuery.ToListAsync();

			// Filter by name (case-insensitive)
			var filteredByName = string.IsNullOrEmpty(NameSearchString)
				? allMeetings
				: allMeetings.Where(m => m.TalksList.Any(t =>
					t.SpeakerName != null &&
					t.SpeakerName.IndexOf(NameSearchString, StringComparison.OrdinalIgnoreCase) >= 0));

			// Filter by topic (case-insensitive)
			var filteredByTopic = string.IsNullOrEmpty(TopicSearchString)
				? filteredByName
				: filteredByName.Where(m => m.TalksList.Any(t =>
					t.Topic != null &&
					t.Topic.IndexOf(TopicSearchString, StringComparison.OrdinalIgnoreCase) >= 0));

			Meeting = filteredByTopic.ToList();
		}
	}
}
