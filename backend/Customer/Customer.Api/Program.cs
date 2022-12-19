using FluentValidation;
using FluentValidation.AspNetCore;
using FastExpressionCompiler;
using Mapster;
using Customer.Api;
using Customer.Core;
using DotCode.LoggerUtils;
using DotCode.ApiUtils;
using Customer.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.InitControllers();

//Automatic Validatrion
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddValidatorsFromAssembly(typeof(Program).Assembly);


//Setup MediatR
var config = TypeAdapterConfig.GlobalSettings;
config.Compiler = exp => exp.CompileFast();
config.Scan(typeof(Program).Assembly);

builder.InitCore(config);

builder.InitInfrastructure();

builder.Services.InitServices(builder.Environment.ApplicationName, builder.Configuration, config);

builder.InitConsoleLogging();

builder.Build()
       .InitApp();


