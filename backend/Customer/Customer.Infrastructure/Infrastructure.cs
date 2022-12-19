using DotCode.RepositoryUtils;
using DotCode.SecurityUtils;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Customer.Core.Repository.Interfaces;
using Customer.Infrastructure.EFCore.Context;
using Customer.Infrastructure.EFCore.Repository;
using Customer.Infrastructure.EFCore.Repository.Interface;

namespace Customer.Infrastructure;

public static class Infrastructure
{
    private const int _defaultConnectionTimeout = 4;
    private const string key = "k3h5/4&75kah5sfjkh/as!hjkfh%a8kjf5ks";

    public static void InitInfrastructure(this WebApplicationBuilder builder)
    {
        builder.Services.InitRepositoryUtils();

        builder.Services.AddScoped<ICustomerSourceRepository, CustomerSourceRepository>();
        builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
        
        builder.Services.InitDatabase(builder.Configuration, builder.Environment.EnvironmentName == "Development");

        builder.Services.AddHealthChecks()
            .AddDbContextCheck<CustomerContext>(tags: new string[] { "alive" });
    }

    private static void InitDatabase(this IServiceCollection services, IConfiguration configuration, bool isDevelopment)
    {
        var encryptedConnectionString = configuration.GetConnectionString("databaseConnection");
        var decryptedConnectionString = Cipher.DecryptString(encryptedConnectionString, key);

        if (!int.TryParse(configuration["EntityFramework:CommandTimeout"], out int defaultCommandTimeout))
        {
            defaultCommandTimeout = _defaultConnectionTimeout;
        }

        services.AddDbContextPool<CustomerContext>(options =>
        {
            options.UseSqlServer(decryptedConnectionString, x =>
            {
                x.MigrationsAssembly("Customer.Migrations");
                x.CommandTimeout(defaultCommandTimeout);
            });
            if (isDevelopment)
            {
                options.EnableSensitiveDataLogging();
            }
        });
    }
}
