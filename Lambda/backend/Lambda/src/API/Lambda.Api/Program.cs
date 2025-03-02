// using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Lambda.Modules.Lessons.Infrastructure;
using Lambda.Common.Presentation.Endpoints;
using Lambda.Common.Infrastructure;
// using HealthChecks.UI.Client;
using Lambda.Common.Application;
using Lambda.Api.Extensions;
using Lambda.Api.Middleware;
using System.Reflection;
using Serilog;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

IServiceCollection services = builder.Services;
IConfiguration configuration = builder.Configuration;

builder.Host.UseSerilog((context, loggerConfig) => loggerConfig.ReadFrom.Configuration(context.Configuration));

// services.AddExceptionHandler<GlobalExceptionHandler>();
// services.AddProblemDetails();

services.AddEndpointsApiExplorer();
services.AddSwaggerDocumentation();

Assembly[] moduleApplicationAssemblies = [
    Lambda.Modules.Lessons.Application.AssemblyReference.Assembly,
];

services.AddApplication(moduleApplicationAssemblies);

string databaseConnectionString = configuration.GetConnectionStringOrThrow("Database");
// string redisConnectionString = configuration.GetConnectionStringOrThrow("Cache");

services.AddInfrastructure(
    // DiagnosticsConfig.ServiceName,
    //[
    //    LessonModele.ConfigureConsumers(redisConnectionString),
    //    // TicketingModule.ConfigureConsumers,
    //    // AttendanceModule.ConfigureConsumers
    //],
    databaseConnectionString);
// redisConnectionString);

// Uri keyCloakHealthUrl = configuration.GetKeyCloakHealthUrl();

// services
// .AddHealthChecks()
// .AddNpgSql(databaseConnectionString);
// .AddRedis(redisConnectionString)
// .AddKeyCloak(keyCloakHealthUrl);


builder.Configuration.AddModuleConfiguration(["lessons",]);

services.AddLessonsModule(configuration);
// services.AddUsersModule(configuration);  

WebApplication app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    app.ApplyMigrations();
}

// app.MapHealthChecks("health", new HealthCheckOptions
// {
//     ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
// });

app.UseLogContext();

app.UseSerilogRequestLogging();

// app.UseExceptionHandler();

// app.UseAuthentication();
// app.UseAuthorization(); 

app.MapEndpoints();

app.Run();
