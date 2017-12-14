using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace SacramentPlanner_Sandbox.Models
{
    public class Speaker
    {
        public int SpeakerID { get; set; }
        public int MeetingID { get; set; } 
        public int PersonID { get; set; }
        public string AssignedTopic { get; set; }
    }
}
