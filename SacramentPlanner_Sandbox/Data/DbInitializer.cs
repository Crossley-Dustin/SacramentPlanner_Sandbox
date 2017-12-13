using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SacramentPlanner.Models;

namespace SacramentPlanner.Data
{
    public class DbInitializer
    {
        public static void Initialize(MeetingContext context)
        {
            context.Database.EnsureCreated();

            // Check for any Person table entries
            if (context.Person.Any())
            {
                return; // DB already seeded
            }

            var people = new Person[]
            {
                new Person{FirstMidName="Carson",LastName="Alexander",Discriminator="Bishopric"}
                , new Person{FirstMidName="Benjamin",LastName="Smith",Discriminator="Member"}

            };

            foreach (Person p in people)
            {
                context.Person.Add(p);
            }
            context.SaveChanges();
        }
    }
}
