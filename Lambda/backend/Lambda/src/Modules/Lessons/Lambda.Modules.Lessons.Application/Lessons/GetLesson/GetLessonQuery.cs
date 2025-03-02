using MediatR;

namespace Lambda.Modules.Lessons.Application.Lessons.GetLesson;

public sealed record GetLessonQuery(Guid LessonId) : IRequest<LessonResponse?>;
