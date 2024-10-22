using Devsu.AccountManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Devsu.AccountManagement.Infrastructure.Data.Configurations;

public class ClientConfiguration : IEntityTypeConfiguration<Client>
{
    public void Configure(EntityTypeBuilder<Client> builder)
    {
        builder.ToTable("clients")
               .HasKey(i => i.Id);

        // Client property mapping
        builder.Property(e => e.Id).HasColumnName("id");
        builder.Property(e => e.PersonId).HasColumnName("person_id");
        builder.Property(e => e.Password).IsRequired().HasColumnName("password");
        builder.Property(e => e.IsActive).HasColumnName("is_active");

        builder.Property(e => e.CreatedAt).HasColumnName("created_at").HasDefaultValueSql("timezone('utc'::text, now())");
        builder.Property(e => e.UpdatedAt).HasColumnName("updated_at");

        // We define the relationship with Person (FK PersonId)
        builder.HasOne(e => e.Person)
               .WithMany()
               .HasForeignKey(c => c.PersonId)
               .OnDelete(DeleteBehavior.Cascade);
    }
}