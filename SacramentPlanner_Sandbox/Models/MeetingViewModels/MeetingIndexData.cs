using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SacramentPlanner_Sandbox.Models.MeetingViewModels
{
    public class MeetingIndexData
    {
        public IEnumerable<Meeting> Meetings { get; set; }
        public IEnumerable<Speaker> Speakers { get; set; }
        public IEnumerable<Person> Persons { get; set; }
        public IEnumerable<Hymn> Hymns { get; set; }
    }
}
