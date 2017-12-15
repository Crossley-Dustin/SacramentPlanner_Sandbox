using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SacramentPlanner_Sandbox.Models
{
    public class Person
    {
        public int PersonID { get; set; }
        [Display(Name = "First Name")]
        public string LastName { get; set; }
        [Display(Name = "Middle Initial")]
        public string MiddleInitial { get; set; }
        [Display(Name = "Last Name")]
        public string FirstName { get; set; }
        [Display(Name = "Member Or Bishopric")]
        public string Discriminator { get; set; }
        [Display(Name = "Full Name")]
        public string FullName { get { return FirstName + " " + MiddleInitial + " " + LastName; }}
    }
}
