using Devsu.AccountManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Devsu.AccountManagement.Infrastructure.Data.Configurations;

public class AccountConfiguration : IEntityTypeConfiguration<Account>
{
    public void Configure(EntityTypeBuilder<Account> builder)
    {
        builder.ToTable("accounts")
               .HasKey(i => i.Id);

        // Client property mapping
        builder.Property(e => e.Id).HasColumnName("id");
        builder.Property(e => e.AccountNumber).HasColumnName("account_number");
        builder.Property(e => e.AccountType).HasColumnName("account_type");
        builder.Property(e => e.InitialBalance).HasColumnName("initial_balance");
        builder.Property(e => e.IsActive).HasColumnName("is_active");

        builder.Property(e => e.ClientId).HasColumnName("client_id");
        builder.Property(e => e.ClientName).HasColumnName("client_name");
        builder.Property(e => e.ClientAddress).HasColumnName("client_address");

        builder.Property(e => e.CreatedAt).HasColumnName("created_at").HasDefaultValueSql("timezone('utc'::text, now())");
        builder.Property(e => e.UpdatedAt).HasColumnName("updated_at");

        builder.HasIndex(a => a.AccountNumber).IsUnique();
    }
}