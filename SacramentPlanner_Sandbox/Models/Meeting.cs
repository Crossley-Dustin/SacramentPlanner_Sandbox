using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SacramentPlanner_Sandbox.Models
{
    public class Meeting
    {
        public int MeetingID { get; set; }
        public DateTime MeetingDate { get; set; }
        public int Conducting { get; set; }
        public Guid OpeningHymn { get; set; }
        public int OpeningPrayer { get; set; }
        public Guid SacramentHymn { get; set; }
        public string IntermediateSong { get; set; }
        public Guid ClosingHymn { get; set; }
        public int ClosingPrayer { get; set; }

        public ICollection<Speaker> Speakers { get; set; }
    }
}
