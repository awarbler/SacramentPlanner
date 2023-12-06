using Microsoft.EntityFrameworkCore;
using SacramentPlanner.Data;

namespace SacramentPlanner.Models
{
	public class SeedData
	{
        public static void Initialize(IServiceProvider serviceProvider)
        {
	        using var context = new SacramentPlannerContext(
		        serviceProvider.GetRequiredService<
			        DbContextOptions<SacramentPlannerContext>>());
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
					Conductor = "Bishop So-and-So",
					OpeningHymn = 67,
					OpeningPrayer = "Austin Slaughter",
					SacramentHymn = 173,
					SpecialMusicalNumber = "",
					ClosingHymn = 80,
					ClosingPrayer = "John Ellefson",
					TalksList = new List<Talk>
					{
						new(){SpeakerName = "Anita Woodford", Topic = "Holy Ghost"},
						new(){SpeakerName = "Aaron Picker", Topic = "Thinking Celestial"}
					}
		        }
	        );
	        context.SaveChanges();
        }
    }
}


