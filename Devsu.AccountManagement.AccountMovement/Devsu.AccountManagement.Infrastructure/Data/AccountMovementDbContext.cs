using Devsu.AccountManagement.Commom;
using Devsu.AccountManagement.Domain.Entities;
using Devsu.AccountManagement.Infrastructure.Data.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Devsu.AccountManagement.Infrastructure.Data;

public class AccountMovementDbContext : BaseContext
{
    public AccountMovementDbContext(DbContextOptions<AccountMovementDbContext> options) 
        : base(options)
    {
    }

    public DbSet<Account> Accounts { get; set; }
    public DbSet<Movement> Movements { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.HasDefaultSchema(Constants.System.ACCOUNT_MOVEMENT_SCHEMA);
        builder.ApplyConfiguration(new AccountConfiguration());
        builder.ApplyConfiguration(new MovementConfiguration());
    }
}