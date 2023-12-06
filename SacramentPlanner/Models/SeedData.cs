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
                    throw new ArgumentNullException("Null RazorPagesMovieContext");
                }

                // Look for any movies.
                if (context.Meeting.Any())
                {
                    return;   // DB has been seeded
                }

                context.Meeting.AddRange(
                    new Meeting
                    {
                        wardName = "Lake Fork Ward",
                        date = DateTime.Parse("1989-2-12"),
                        openingPrayer = "Romantic Comedy",
                        openingHymn = "Romantic Comedy",
                        sacramentHymn = "Romantic Comedy",
                        restHymn = "Romantic Comedy",
                        specialMusicalNumber = "Romantic Comedy",
                        closingHymn = "Romantic Comedy",

                        closingPrayer = "Romantic Comedy",
                        
                    }
                );
                context.SaveChanges();
            }
        }
    }

}


