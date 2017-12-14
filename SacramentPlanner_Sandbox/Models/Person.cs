using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SacramentPlanner_Sandbox.Models
{
    public class Person
    {
        public int PersonID { get; set; }
        public string LastName { get; set; }
        public string FirstMidName { get; set; }
        public string Discriminator { get; set; }
    }
}
