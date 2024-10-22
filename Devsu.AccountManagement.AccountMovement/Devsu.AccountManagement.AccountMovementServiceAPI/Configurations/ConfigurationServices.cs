using Devsu.AccountManagement.Application.Interfaces;
using Devsu.AccountManagement.Application.Mappers;
using Devsu.AccountManagement.Application.Services;
using Devsu.AccountManagement.Domain.Repositories;
using Devsu.AccountManagement.Infrastructure.Data;
using Devsu.AccountManagement.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Devsu.AccountManagement.AccountMovementAPI.Configurations;

public static class ConfigurationServices
{
    public static IServiceCollection RegisterConfigurations(this IServiceCollection services, IConfiguration configuration)
    {
        services.RegisterContext(configuration);
        services.RegisterServices();
        services.RegisterRepositories();

        services.AddAutoMapper(typeof(DevsuProfile));

        return services;
    }

    private static IServiceCollection RegisterContext(this IServiceCollection services, IConfiguration configuration)
    {
        //Register context for Product Schema
        services.AddDbContext<AccountMovementDbContext>(options =>
        {
            options.UseNpgsql(configuration.GetConnectionString("DevsuConnection"));
        });

        services.AddDistributedMemoryCache();

        return services;
    }

    private static IServiceCollection RegisterServices(this IServiceCollection services)
    {
        services.AddScoped<IAccountService, AccountService>();

        return services;
    }

    private static IServiceCollection RegisterRepositories(this IServiceCollection services)
    {
        services.AddScoped<IAccountRepository, AccountRepository>();

        return services;
    }
}
