using Customer.Core;
using FastExpressionCompiler;
using Hangfire;
using Hangfire.SqlServer;
using Mapster;
using MapsterMapper;
using System.Reflection;
using Customer.Infrastructure;
using Customer.Worker.BackgroundWorkers;
using Customer.Worker.Settings;
using DotCode.LoggerUtils;

var builder = WebApplication.CreateBuilder(args);

var config = TypeAdapterConfig.GlobalSettings;
config.Compiler = exp => exp.CompileFast();
config.Scan(Assembly.GetExecutingAssembly());

var mapperConfig = new Mapper(config);
builder.Services.AddSingleton(mapperConfig);

builder.InitCore(config);

builder.InitInfrastructure();

builder.Services.Configure<TaskSettings>(builder.Configuration.GetSection(TaskSettings.Setting));

builder.Services.AddHangfire(config =>
{
    config.UseSimpleAssemblyNameTypeSerializer()
    .UseRecommendedSerializerSettings()
    .UseSqlServerStorage(builder.Configuration.GetConnectionString("databaseConnection"), new SqlServerStorageOptions
    {
        CommandBatchMaxTimeout = TimeSpan.FromMinutes(5),
        SlidingInvisibilityTimeout = TimeSpan.FromMinutes(5),
        QueuePollInterval = TimeSpan.Zero,
        UseRecommendedIsolationLevel = true,
        DisableGlobalLocks = true
    });

    builder.InitConsoleLogging();

    builder.Services.AddHangfireServer();

    builder.Services.AddSingleton<CustomerBackgroundTasks>();

    var app = builder.Build();

    app.UseHangfireDashboard("/Customer/hangfire");
    app.MapHangfireDashboard("/Customer/hangfire");

    app.MapHealthChecks("/Healthz/ready", new Microsoft.AspNetCore.Diagnostics.HealthChecks.HealthCheckOptions
    {
        Predicate = healthy => healthy.Tags.Contains("alive")
    });
    app.MapHealthChecks("/Healthz/live", new Microsoft.AspNetCore.Diagnostics.HealthChecks.HealthCheckOptions
    {
        Predicate = _ => false
    });

    BackgroundJobs.Init(app.Services);

    app.Run();
});

