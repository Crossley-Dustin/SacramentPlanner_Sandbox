using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SacramentPlanner_Sandbox.Models
{
    public class Meeting
    {
        public int MeetingID { get; set; }
        [Required]
        [DisplayFormat(DataFormatString = "{0:MMddyyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Meeting Date")]
        public DateTime MeetingDate { get; set; }
        public int Conducting { get; set; }
        [Display(Name = "Opening Hymn")]
        public Guid OpeningHymn { get; set; }
        [Display(Name = "Opening Prayer")]
        public int OpeningPrayer { get; set; }
        [Display(Name = "Sacrament Hymn")]
        public Guid SacramentHymn { get; set; }
        [Display(Name = "Intermediate Song")]
        public string IntermediateSong { get; set; }
        [Display(Name = "Closing Hymn")]
        public Guid ClosingHymn { get; set; }
        [Display(Name = "Closing Prayer")]
        public int ClosingPrayer { get; set; }

        public ICollection<Speaker> Speakers { get; set; }
    }
}
