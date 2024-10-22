using Devsu.AccountManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Devsu.AccountManagement.Infrastructure.Data.Configurations;

public class MovementConfiguration : IEntityTypeConfiguration<Movement>
{
    public void Configure(EntityTypeBuilder<Movement> builder)
    {
        builder.ToTable("movements")
               .HasKey(i => i.Id);

        // Client property mapping
        builder.Property(e => e.Id).HasColumnName("id");
        builder.Property(e => e.Date).HasColumnName("date");
        builder.Property(e => e.MovementType).HasColumnName("movement_type");
        builder.Property(e => e.Value).HasColumnName("value");
        builder.Property(e => e.Balance).HasColumnName("balance");

        builder.Property(e => e.CreatedAt).HasColumnName("created_at").HasDefaultValueSql("timezone('utc'::text, now())");
        builder.Property(e => e.UpdatedAt).HasColumnName("updated_at");

        // We define the relationship with Person (FK PersonId)
        builder.HasOne(e => e.Account)
               .WithMany()
               .HasForeignKey(c => c.AccountId)
               .OnDelete(DeleteBehavior.Cascade);
    }
}