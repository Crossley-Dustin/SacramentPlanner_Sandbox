using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SacramentPlanner_Sandbox.Models
{
    public class Hymn
    {
        public Guid HymnID { get; set; }
        [Display(Name = "Hymn Number")]
        public int HymnNumber { get; set; }
        [Display(Name = "Hymn Name")]
        public string HymnName { get; set; }
    }
}
