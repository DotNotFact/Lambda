using Lambda.Modules.Lessons.Domain.Lessons;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lambda.Modules.Lessons.Infrastructure.Lessons;

internal sealed class LessonConfiguration : IEntityTypeConfiguration<Lesson>
{
    public void Configure(EntityTypeBuilder<Lesson> builder)
    {
        builder.HasKey(x => x.Uid);

        // builder.HasOne<Category>().WithMany();
    }
}
