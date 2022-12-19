using Customer.Api.Swagger;
using Mapster;
using MapsterMapper;

namespace Customer.Api
{
    public static class Services
    {
        public static void InitServices(this IServiceCollection services, string applicationName, IConfiguration configuration, TypeAdapterConfig config)
        {
            services.AddEndpointsApiExplorer();
            services.AddApiVersioning(setup =>
            {
                setup.AssumeDefaultVersionWhenUnspecified = true;
                setup.ReportApiVersions = true;
            });

            services.AddVersionedApiExplorer(setup =>
            {
                setup.GroupNameFormat = "'v'VVV";
                setup.SubstituteApiVersionInUrl = true;
            });

            services.AddSwaggerGen();
            services.ConfigureOptions<ConfigureSwaggerOptions>();

            var mapperConfig = new Mapper(config);
            services.AddSingleton<IMapper>(mapperConfig);
        }
    }
}
