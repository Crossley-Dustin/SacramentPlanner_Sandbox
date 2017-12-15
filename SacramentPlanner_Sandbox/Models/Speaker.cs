using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SacramentPlanner_Sandbox.Models
{
    public class Speaker
    {
        public int SpeakerID { get; set; }
        [Display(Name = "Meeting")]
        public int MeetingID { get; set; }
        [Display(Name = "Person")]
        public int PersonID { get; set; }
        [Display(Name = "Assigned Topic")]
        public string AssignedTopic { get; set; }
    }
}
