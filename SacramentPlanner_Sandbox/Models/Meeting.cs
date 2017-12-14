using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SacramentPlanner.Models
{
    public class Meeting
    {
        public int MeetingID { get; set; }
        public DateTime MeetingDate { get; set; }
        public Person Conducting { get; set; }
        public Hymn OpeningHymn { get; set; }
        public Person OpeningPrayer { get; set; }
        public Hymn SacramentHymn { get; set; }
        public string IntermediateSong { get; set; }
        public Hymn ClosingHymn { get; set; }
        public Person ClosingPrayer { get; set; }

        public ICollection<Speaker> Speaker { get; set; }
    }
}
