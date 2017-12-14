using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace SacramentPlanner.Models
{
    public class Speaker
    {
        public int SpeakerID { get; set; }
        public Meeting MeetingID { get; set; } 
        public Person PersonID { get; set; }
        public string AssignedTopic { get; set; }
    }
}
