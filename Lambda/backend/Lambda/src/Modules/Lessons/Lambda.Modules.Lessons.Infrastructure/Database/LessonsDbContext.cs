using Lambda.Common.Application.Data;
using Lambda.Modules.Lessons.Domain.Lessons;
using Lambda.Modules.Lessons.Infrastructure.Lessons;
using Microsoft.EntityFrameworkCore;

namespace Lambda.Modules.Lessons.Infrastructure.Database;

public sealed class LessonsDbContext(DbContextOptions<LessonsDbContext> options) : DbContext(options), IUnitOfWork
{
    internal DbSet<Lesson> Lessons { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema(Schemas.Lessons);

        modelBuilder.ApplyConfiguration(new LessonConfiguration());
    }
}

