using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace SacramentPlanner.Models
{
	public class Meeting
	{
		public int Id { get; set; }

		[Display(Name = "Ward Name")]
		public string? WardName { get; set; }

		[DataType(DataType.Date)]
		[Display(Name = "Date of Meeting")]
		[Required]
		public DateTime Date { get; set; }

		public string? Conductor { get; set; }

		// TODO: Store hymns as ints - create a file (likely JSON array) to look up names
		// Names are from https://www.churchofjesuschrist.org/music/index/hymns/number?lang=eng
		// https://stackoverflow.com/questions/29841503/json-serialization-deserialization-in-asp-net-core
		[Display(Name = "Opening Hymn")]
		[Required]
		public int OpeningHymn { get; set; }

		[Display(Name = "Opening Prayer (Invocation)")]
		[Required]
		public string? OpeningPrayer { get; set; }

		// Sacrament hymns are 169-196, consider enforcing this range
		[Display(Name = "Sacrament Hymn")]
		[Required]
		public int SacramentHymn { get; set; }
		
		[Display(Name = "Rest Hymn")]
		public int RestHymn { get; set; }

		// TODO in Create/Edit: Don't allow a musical number and a rest hymn at the same time
		//       (Select box to choose type that hides the one not selected? (In JS))
		[Display(Name = "Special Musical Number")]
		public string? SpecialMusicalNumber { get; set; }
		
		// For further hymnforcement, disallow gendered/choir pieces (309-337) - review "using the hymnbook"
		[Display(Name = "Closing Hymn")]
		[Required]
		public int ClosingHymn { get; set; }

		[Display(Name = "Closing Prayer (Benediction)")]
		[Required]
		public string? ClosingPrayer { get; set; }

		// TODO: Store in database as newline(?)-separated values, but treat it as a data structure
		//        Heck, why not store it as JSON?
		//        Possible approach: https://stackoverflow.com/a/15221028
		//        Store topics in here too?
		//        Whatever the case, there needs to be some kind of special frontend stuff in Create/Edit...
		//        - Modification of https://codepen.io/redmangospros/pen/POVmwQ/

		/// <summary>
		/// A list of Talks stored as JSON, since single strings can be stored in the database just fine.
		/// </summary>
		[Display(Name="Talks (JSON)")]
		public string TalksJson { get; set; } = "";

		/// <summary>
		/// A list of Talks backed by a JSON string. <br/>
		/// TalksJson is stored in the database; this property can be used for more convenient access.
		/// </summary>
		// TODO: Convert to JSON on DB updates instead of on list updates?
		//        (Have these getters and setters in TalksJson instead? Does that work?)
		[NotMapped]
		[Display(Name="Talks (List)")]
		public List<Talk> TalksList
		{
			get => JsonConvert.DeserializeObject<List<Talk>>(TalksJson) ?? new List<Talk>();
			set => TalksJson = JsonConvert.SerializeObject(value);
		}
	}

	public struct Talk
	{
		public string SpeakerName { get; set; }
		public string Topic { get; set; }
	}
}

