using Lambda.Common.Domain;

namespace Lambda.Modules.Lessons.Domain.Lessons;

public sealed class LessonCanceledDomainEvent(Guid lessonId) : DomainEvent
{
    public Guid LessonId { get; init; } = lessonId;
}
