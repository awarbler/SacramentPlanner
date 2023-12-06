using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using SacramentPlanner.Data;

namespace SacramentPlanner.Models
{
	public class SeedData
	{
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new SacramentPlannerContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<SacramentPlannerContext>>()))
            {
                if (context == null || context.Meeting == null)
                {
                    throw new ArgumentNullException("Null SacramentPlannerContext");
                }

                // Look for any movies.
                if (context.Meeting.Any())
                {
                    return;   // DB has been seeded
                }

                context.Meeting.AddRange(
                    new Meeting
                    {
                        WardName = "Lake Fork Ward",
                        Date = DateTime.Parse("1989-2-12"),
                        OpeningPrayer = "Romantic Comedy",
                        OpeningHymn = "Romantic Comedy",
                        SacramentHymn = "Romantic Comedy",
                        RestHymn = "Romantic Comedy",
                        SpecialMusicalNumber = "Romantic Comedy",
                        ClosingHymn = "Romantic Comedy",

                        ClosingPrayer = "Romantic Comedy",
                        
                    }
                );
                context.SaveChanges();
            }
        }
    }

}


