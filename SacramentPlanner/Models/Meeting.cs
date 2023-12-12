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
		[Display(Name = "Meeting Date")]
		[Required]
		public DateTime Date { get; set; }

		public string? Conductor { get; set; }

		[Display(Name = "Opening Hymn")]
		[Required]
		[Range(1,341, ErrorMessage = "Please choose a hymn from the English LDS hymnbook (1-341).")]
		public int OpeningHymn { get; set; }

		[Display(Name = "Opening Prayer (Invocation)")]
		[Required]
		public string? OpeningPrayer { get; set; }

		[Display(Name = "Sacrament Hymn")]
		[Required]
		[Range(169, 196, ErrorMessage = "Please choose a sacrament-related hymn (169-196).")]
		public int SacramentHymn { get; set; }
		
		[Display(Name = "Rest Hymn")]
		[Range(1, 341, ErrorMessage = "Please choose a hymn from the English LDS hymnbook (1-341).")]
		public int? RestHymn { get; set; }

		// TODO in Create/Edit: Don't allow a musical number and a rest hymn at the same time
		//       (Select box to choose type that hides the one not selected? (In JS))
		[Display(Name = "Special Musical Number")]
		public string? SpecialMusicalNumber { get; set; }
		
		// For further hymnforcement, maybe disallow gendered/choir pieces (309-337) - review "using the hymnbook"
		[Display(Name = "Closing Hymn")]
		[Required]
		[Range(1, 341, ErrorMessage = "Please choose a hymn from the English LDS hymnbook (1-341).")]
		public int ClosingHymn { get; set; }

		[Display(Name = "Closing Prayer (Benediction)")]
		[Required]
		public string? ClosingPrayer { get; set; }

		/// <summary>
		/// A list of Talks stored as JSON, since single strings can be stored in the database without issue.
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
		[Display(Name="Speakers")]
		public List<Talk> TalksList
		{
			get => JsonConvert.DeserializeObject<List<Talk>>(TalksJson) ?? new List<Talk>();
			set => TalksJson = JsonConvert.SerializeObject(value);
		}
	}

	public struct Talk
	{
        [Required(ErrorMessage = "Speaker Name is required")]
        public string SpeakerName { get; set; }

        [Required(ErrorMessage = "Topic is required")]
        public string Topic { get; set; }
	}
}

