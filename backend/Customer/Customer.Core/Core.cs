using Mapster;
using MediatR;
using DotCode.CqrsUtils;
using FluentValidation;
using Microsoft.AspNetCore.Builder;

namespace Customer.Core
{
    public static class Core
    {
        public static void InitCore(this WebApplicationBuilder builder, TypeAdapterConfig config)
        {
            //Mediator Service
            builder.Services.AddMediatR(typeof(Core).Assembly);
            builder.Services.InitCqrsUtils();

            //Map Scan
            config.Scan(typeof(Core).Assembly);

            builder.Services.AddValidatorsFromAssembly(typeof(Core).Assembly);
        }
    }
}
