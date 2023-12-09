﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SacramentPlanner.Data;
using SacramentPlanner.Models;
using Newtonsoft.Json;

namespace SacramentPlanner.Pages
{
    public class SpeakerTopic
    {
        public string SpeakerName { get; set; }
        public string Topic { get; set; }
    }

    public class DetailsModel : PageModel
    {
        private readonly SacramentPlanner.Data.SacramentPlannerContext _context;

        public DetailsModel(SacramentPlanner.Data.SacramentPlannerContext context)
        {
            _context = context;
        }

        public List<SpeakerTopic> SpeakerTopicList { get; set; }
        public Meeting Meeting { get; set; } = default!;
        public int SpeakersPreInterim { get; set; } = 0;

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

            // Fetch the JSON string from the database record that matches the id
            string jsonFromDatabase = Meeting.TalksJson.ToString();

            // Deserializes the JSON string into a list of SpeakerTopic objects
            SpeakerTopicList = JsonConvert.DeserializeObject<List<SpeakerTopic>>(jsonFromDatabase);

            double tempConversion;

            // Calculate the midpoint of the meeting based on number of speakers
            tempConversion = Math.Ceiling((double)SpeakerTopicList.Count() / 2);
            SpeakersPreInterim = (int)tempConversion;

            return Page();
        }
    }
}

