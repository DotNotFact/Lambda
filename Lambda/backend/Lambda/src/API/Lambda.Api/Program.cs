// using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Lambda.Modules.Lessons.Infrastructure;
// using HealthChecks.UI.Client;
using Lambda.Api.Extensions;
using Lambda.Api.Middleware;
using Serilog;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

IServiceCollection services = builder.Services;
IConfiguration configuration = builder.Configuration;

builder.Host.UseSerilog((context, loggerConfig) => loggerConfig.ReadFrom.Configuration(context.Configuration));

// services.AddExceptionHandler<GlobalExceptionHandler>();
// services.AddProblemDetails();

services.AddEndpointsApiExplorer();
services.AddSwaggerDocumentation();

services.AddLessonsModule(builder.Configuration);

// Assembly[] moduleApplicationAssemblies = [
//     Lambda.Modules.Users.Application.AssemblyReference.Assembly,
//     Lambda.Modules.Events.Application.AssemblyReference.Assembly,
//     Lambda.Modules.Ticketing.Application.AssemblyReference.Assembly,
//     Lambda.Modules.Attendance.Application.AssemblyReference.Assembly, ];

// services.AddApplication(moduleApplicationAssemblies);

// string databaseConnectionString = configuration.GetConnectionStringOrThrow("Database");
// string redisConnectionString = configuration.GetConnectionStringOrThrow("Cache");

// services.AddInfrastructure(
//     DiagnosticsConfig.ServiceName,
//     [
//         EventsModule.ConfigureConsumers(redisConnectionString),
//         TicketingModule.ConfigureConsumers,
//         AttendanceModule.ConfigureConsumers
//     ],
//     databaseConnectionString,
//     redisConnectionString);

// Uri keyCloakHealthUrl = configuration.GetKeyCloakHealthUrl();

// services
// .AddHealthChecks()
// .AddNpgSql(databaseConnectionString);
// .AddRedis(redisConnectionString)
// .AddKeyCloak(keyCloakHealthUrl);


// configuration.AddModuleConfiguration(["users", "events", "ticketing", "attendance"]);
// 
// services.AddEventsModule(configuration); 
// services.AddUsersModule(configuration); 
// services.AddTicketingModule(configuration); 
// services.AddAttendanceModule(configuration);


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

LessonsModule.MapEndpoints(app);

// app.MapEndpoints();

app.Run();
