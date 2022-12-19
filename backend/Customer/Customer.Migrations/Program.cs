using DotCode.LoggerUtils;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.DependencyInjection;
using Customer.Infrastructure;
using Customer.Infrastructure.EFCore.Context;

Console.WriteLine("Applying migrations...");

var builder = WebApplication.CreateBuilder(args);

builder.InitInfrastructure();
//builder.InitConsoleLogging();

var app = builder.Build();

var context = (CustomerContext?)app.Services.GetService(typeof(CustomerContext));
if (context != null)
{
    var pendingMigrations = await context.Database.GetPendingMigrationsAsync();
    

    var version = builder.Configuration["Migrations:SpecificVersion"];

    if (string.IsNullOrWhiteSpace(version))
    {
        if (pendingMigrations.Any())
        {
            Console.WriteLine($"You have {pendingMigrations.Count()} pending migrations.");
            Console.WriteLine("Applying them now...");
            await context.Database.MigrateAsync();
        }
    }
    else
    {
        var migrator = context.GetInfrastructure().GetService<IMigrator>();
        if(migrator != null)
            await migrator.MigrateAsync(version);
    }
    var lastAppliedMigration = (await context.Database.GetAppliedMigrationsAsync()).LastOrDefault();

    Console.WriteLine($"You're on schema version: {lastAppliedMigration}");
}

Console.WriteLine("Done!");
