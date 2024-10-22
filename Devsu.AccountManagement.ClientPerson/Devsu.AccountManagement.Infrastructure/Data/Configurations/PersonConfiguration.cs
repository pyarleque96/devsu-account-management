using Devsu.AccountManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Devsu.AccountManagement.Infrastructure.Data.Configurations;

public class PersonConfiguration : IEntityTypeConfiguration<Person>
{
    public void Configure(EntityTypeBuilder<Person> builder)
    {
        builder.ToTable("persons")
               .HasKey(i => i.Id);

        // Client property mapping
        builder.Property(p => p.Id).HasColumnName("id");

        builder.Property(e => e.Name).IsRequired().HasColumnName("name");
        builder.Property(e => e.Gender).HasColumnName("gender");
        builder.Property(e => e.Age).IsRequired().HasColumnName("age");
        builder.Property(e => e.Identification).IsRequired().HasColumnName("identification");
        builder.Property(e => e.Address).HasColumnName("address");
        builder.Property(e => e.Phone).HasColumnName("phone");

        builder.Property(e => e.CreatedAt).HasColumnName("created_at").HasDefaultValueSql("timezone('utc'::text, now())");
        builder.Property(e => e.UpdatedAt).HasColumnName("updated_at");
    }
}