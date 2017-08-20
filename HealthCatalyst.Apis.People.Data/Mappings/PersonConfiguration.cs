using HealthCatalyst.Apis.People.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HealthCatalyst.Apis.People.Data.Mappings
{
    public class PersonConfiguration : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.ToTable("Person");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.FirstName).IsRequired().HasMaxLength(50);
            builder.Property(p => p.LastName).IsRequired().HasMaxLength(50);
            builder.Property(p => p.BirthDate);
            builder.Property(p => p.Interests);
            builder.Property(p => p.PictureFileName).HasMaxLength(50);
            builder.Property(p => p.AddressLine1).HasMaxLength(50);
            builder.Property(p => p.AddressLine2).HasMaxLength(50);
            builder.Property(p => p.City).HasMaxLength(50);
            builder.Property(p => p.State).HasMaxLength(50);
            builder.Property(p => p.Zip).HasMaxLength(10);
            builder.Property(p => p.Country).HasMaxLength(50);
        }
    }
}
