using Devsu.AccountManagement.Commom;
using Devsu.AccountManagement.Domain.Entities;
using Devsu.AccountManagement.Infrastructure.Data.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Devsu.AccountManagement.Infrastructure.Data;

public class ClientPersonDbContext : DbContext
{
    public ClientPersonDbContext(DbContextOptions<ClientPersonDbContext> options)
        : base(options)
    {
    }

    public DbSet<Client> Clients { get; set; }
    public DbSet<Person> Persons { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.HasDefaultSchema(Constants.System.CLIENT_PERSON_SCHEMA);
        builder.ApplyConfiguration(new ClientConfiguration());
        builder.ApplyConfiguration(new PersonConfiguration());
    }
}