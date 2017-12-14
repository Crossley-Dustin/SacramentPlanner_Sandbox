using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SacramentPlanner.Models
{
    public class Hymn
    {
        public Guid HymnID { get; set; }
        public int HymnNumber { get; set; }
        public string HymnName { get; set; }
    }
}
