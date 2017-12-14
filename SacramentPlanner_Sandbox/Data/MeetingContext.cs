using SacramentPlanner_Sandbox.Models;
using Microsoft.EntityFrameworkCore;

namespace SacramentPlanner_Sandbox.Data
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>().ToTable("Person");
            modelBuilder.Entity<Meeting>().ToTable("Meeting");
            modelBuilder.Entity<Hymn>().ToTable("Hymn");
            modelBuilder.Entity<Speaker>().ToTable("Speaker");

            modelBuilder.Entity<Speaker>()
                .HasIndex(c => new { c.SpeakerID, c.MeetingID, c.PersonID});
        }
    }
}