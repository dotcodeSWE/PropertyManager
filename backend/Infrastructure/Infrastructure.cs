using Domain.Domain.Authentication;
using Domain.Repository.Interfaces;
using DotCode.SecurityUtils;
using Infrastructure.Context;
using Infrastructure.EFCore.Context;
using Infrastructure.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class Infrastructure
{
    private const string key = "k3h5/4&75kah5sfjkh/as!hjkfh%a8kjf5ks";

    public static void InitInfrastructure(this WebApplicationBuilder builder)
    {
        builder.Services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
        builder.Services.AddScoped<IAreaRepository, AreaRepository>();
        builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
        builder.Services.AddScoped<IChoreRepository, ChoreRepository>();
        builder.Services.AddScoped<IChoreStatusRepository, ChoreStatusRepository>();
        builder.Services.AddScoped<ICustomerChoreRepository, CustomerChoreRepository>();
        builder.Services.AddScoped<ITeamRepository, TeamRepository>();
        builder.Services.AddScoped<IPeriodicRepository, PeriodicRepository>();
        builder.Services.AddScoped<IUserRepository, UserRepository>();
        builder.Services.AddScoped<ITeamMemberRepository, TeamMemberRepository>();
        builder.Services.AddScoped<IChoreCommentRepository, ChoreCommentRepository>();

        builder.Services.InitDatabase(builder.Configuration, builder.Environment.EnvironmentName == "Development");
    }

    private static void InitDatabase(this IServiceCollection services, IConfiguration configuration, bool isDevelopment)
    {
        var encryptedConnectionString = configuration.GetConnectionString("devDBconnection");
        var decryptedConnectionString = Cipher.DecryptString(encryptedConnectionString!, key);

        services.AddDbContext<AuthDbContext>(options => options.UseSqlServer(decryptedConnectionString));

        var useInMemoryDatabase = configuration["ForceUseInMemoryDatabase"] != null ?
                   bool.Parse(configuration["ForceUseInMemoryDatabase"]!) :
                   configuration.GetConnectionString("databaseConnection") != null ?
                   false : true;

        if (useInMemoryDatabase)
        {
            services.AddDbContext<PropertyManagerContext>(c => c.UseInMemoryDatabase("Database"));
        }
        else
        {
            services.AddDbContext<PropertyManagerContext>(options => options.UseSqlServer(decryptedConnectionString));
        }
    }
}