using System;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace SacramentPlanner.Models
{
	public class Meeting
	{
		public int Id { get; set; }

		[Display(Name = "Ward Name")]
		public string? WardName { get; set; }

		public string? Conductor { get; set; }

		[DataType(DataType.Date)]
		public DateTime Date { get; set; }

		[Display(Name = "Opening Prayer")]
		public string? OpeningPrayer { get; set; }

		// TODO: Store hymns as ints - create a file (likely JSON array) to look up names
		// Grab names from https://www.churchofjesuschrist.org/music/index/hymns/number?lang=eng
		[Display(Name = "Opening Hymn")]
		public string? OpeningHymn { get; set; }
		
		[Display(Name = "Sacrament Hymn")]
		public string? SacramentHymn { get; set; }
		
		[Display(Name = "Rest Hymn")]
		public string? RestHymn { get; set; }

		// TODO in Create/Edit: Don't allow a musical number and a rest hymn at the same time
		//       (Select box to choose type that hides the one not selected? (In JS))
		[Display(Name = "Special Musical Number")]
		public string? SpecialMusicalNumber { get; set; }
		
		[Display(Name = "Closing Hymn")]
		public string? ClosingHymn { get; set; }

		[Display(Name = "Closing Prayer")]
		public string? ClosingPrayer { get; set; }

		//public ICollection<Speaker>? speakers { get; set; }

		// TODO: Store in database as newline(?)-separated values, but treat it as a data structure
		//        Possible approach: https://stackoverflow.com/a/15221028
		//        Store topics in here too?
		//        Whatever the case, there needs to be some kind of special frontend stuff in Create/Edit...
		[Display(Name = "Speakers")]
		public string? SpeakerNames
		{
			get;
			set;
		}
		/* {
			 string returnValue = "";
			 if (speakers != null)
			 {
				 foreach (Speaker s in speakers)
				 {
					 returnValue += s.name + "\n";
				 }

			 }
			 return returnValue;
		 }*/
	}

}

