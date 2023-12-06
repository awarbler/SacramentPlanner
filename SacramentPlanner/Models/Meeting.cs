using System;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace SacramentPlanner.Models
{
    public class Meeting
	{
        public int Id { get; set; }


        [Display(Name = "Ward Name")]
        public string? wardName { get; set; }


        [Display(Name = "Conductor")]
        public string? conductor { get; set; }


        [DataType(DataType.Date)]
        [Display(Name = "Date")]
        public DateTime date { get; set; }

        [Display(Name = "Opening Prayer")]
        public string? openingPrayer { get; set; }

        [Display(Name = "Opening Hymn")]
        public string? openingHymn { get; set; }


        [Display(Name = "Sacrament Hymn")]
        public string? sacramentHymn { get; set; }


        [Display(Name = "Rest Hymn")]
        public string? restHymn { get; set; }

        [Display(Name = "Special Musical Number")]
        public string? specialMusicalNumber { get; set; }


        [Display(Name = "Closing Hymn")]
        public string? closingHymn { get; set; }

        [Display(Name = "Closing Prayer")]
        public string? closingPrayer { get; set; }

        //public ICollection<Speaker>? speakers { get; set; }

        [Display(Name = "Speaker")]
        public string? speakerNames
        {
            get;
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

