using SacramentPlanner.Models;
using Microsoft.EntityFrameworkCore;

namespace SacramentPlanner.Data
{
    public class MeetingContext : DbContext
    {
        public MeetingContext(DbContextOptions<MeetingContext> options) : base(options)
        {
        }

        public DbSet<Person> Person { get; set; }
        public DbSet<Meeting> Meeting { get; set; }
        public DbSet<Hymn> Hymn { get; set; }
        public DbSet<Speaker> Speaker { get; set; }
    }
}