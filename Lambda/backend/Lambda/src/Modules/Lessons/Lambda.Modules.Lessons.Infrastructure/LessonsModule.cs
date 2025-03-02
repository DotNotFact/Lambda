using FluentValidation;
using Lambda.Modules.Lessons.Application.Abstractions.Data;
using Lambda.Modules.Lessons.Domain.Lessons;
using Lambda.Modules.Lessons.Infrastructure.Data;
using Lambda.Modules.Lessons.Infrastructure.Database;
using Lambda.Modules.Lessons.Infrastructure.Lessons;
using Lambda.Modules.Lessons.Presentation.Lessons;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Npgsql;

namespace Lambda.Modules.Lessons.Infrastructure;

public static class LessonsModule
{
    public static void MapEndpoints(IEndpointRouteBuilder app)
    {
        LessonEndpoints.MapEndpoints(app);
    }

    public static IServiceCollection AddLessonsModule(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddMediatR(config =>
        {
            config.RegisterServicesFromAssembly(Application.AssemblyReference.Assembly);
        });

        services.AddValidatorsFromAssembly(Application.AssemblyReference.Assembly, includeInternalTypes: true);

        services.AddInfrastructure(configuration);

        return services;
    }

    private static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        string databaseConnectionString = configuration.GetConnectionString("Database")!;

        NpgsqlDataSource npgsqlDataSource = new NpgsqlDataSourceBuilder(databaseConnectionString).Build();
        services.TryAddSingleton(npgsqlDataSource);

        services.AddScoped<IDbConnectionFactory, DbConnectionFactory>();

        services.AddDbContext<LessonsDbContext>(options =>
            options
                .UseNpgsql(
                    databaseConnectionString,
                    npgsqlOptions => npgsqlOptions
                        .MigrationsHistoryTable(HistoryRepository.DefaultTableName, Schemas.Lessons))
                .UseSnakeCaseNamingConvention());

        services.AddScoped<ILessonRepository, LessonRepository>();

        services.AddScoped<IUnitOfWork>(sp => sp.GetRequiredService<LessonsDbContext>());
    }
}
