using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SacramentPlanner.Models;
using Newtonsoft.Json;

namespace SacramentPlanner.Pages
{
    public class DetailsModel : PageModel
    {
        private readonly SacramentPlanner.Data.SacramentPlannerContext _context;

        public DetailsModel(SacramentPlanner.Data.SacramentPlannerContext context)
        {
            _context = context;
        }

        public List<string> HymnNames { get; set; }
        const string HymnNamesFile = "wwwroot/js/HymnNames-eng.min.json";
		public Meeting Meeting { get; set; } = default!;
        public int SpeakersPreInterim = 0;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Meeting == null)
            {
                return NotFound();
            }

            var meeting = await _context.Meeting.FirstOrDefaultAsync(m => m.Id == id);
            if (meeting == null)
            {
                return NotFound();
            }
            else
            {
                Meeting = meeting;
            }

            // Calculate the midpoint of the meeting based on number of speakers
            var tempConversion = Math.Ceiling((double)Meeting.TalksList.Count / 2);
            SpeakersPreInterim = (int)tempConversion;

            // Open and parse the hymn names file
            try
            {
                var jsonContent = await System.IO.File.ReadAllTextAsync(HymnNamesFile);
                HymnNames = JsonConvert.DeserializeObject<List<string>>(jsonContent)!;
            }
            catch (Exception ex)
            {
                // Handle exceptions
            }

            return Page();
        }
    }
}

