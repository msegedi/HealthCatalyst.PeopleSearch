using HealthCatalyst.Apis.People.Data.Entities;
using HealthCatalyst.Apis.People.Data.Mappings;
using Microsoft.EntityFrameworkCore;

namespace HealthCatalyst.Apis.People.Data.Infrastructure
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Person> People { get; set; }

        public DatabaseContext()
        {
        }

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured) return;

            // Horrible crime for the sake of supporting seed data. I would NOT do it this way in a production app! To make matters worse, the seed data migration will only run once and not every time migrations are applied.
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=People;Trusted_Connection=True;MultipleActiveResultSets=true");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new PersonConfiguration());
        }
    }
}
