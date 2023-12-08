using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SacramentPlanner.Data;
using SacramentPlanner.Models;

namespace SacramentPlanner.Pages
{
    public class CreateModel : PageModel
    {
        private readonly SacramentPlanner.Data.SacramentPlannerContext _context;

        public CreateModel(SacramentPlanner.Data.SacramentPlannerContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Meeting Meeting { get; set; } = default!;

        public IActionResult OnGet()
        {
            return Page();
        }
        
        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Meeting == null || Meeting == null)
            {
                return Page();
            }

            var talksList = new List<Talk>();

            // Retrieve form values and group speaker with its corresponding topic
            var speakers = Request.Form["Speaker"];
            var topics = Request.Form["Topic"];

            if (speakers.Count > 0 && topics.Count > 0)
            {
                for (int i = 0; i < speakers.Count; i++)
                {
                    talksList.Add(new Talk { SpeakerName = speakers[i], Topic = topics[i] });
                }
            }
            Meeting.TalksList = talksList;

            _context.Meeting.Add(Meeting);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
