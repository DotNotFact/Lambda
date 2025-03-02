using FluentValidation;

namespace Lambda.Modules.Lessons.Application.Lessons.CreateLesson;

internal sealed class CreateLessonCommandValidator : AbstractValidator<CreateLessonCommand>
{
    public CreateLessonCommandValidator()
    {
        RuleFor(c => c.Subject).NotEmpty().MaximumLength(100);
        RuleFor(c => c.Description).NotEmpty().MaximumLength(500);
        RuleFor(c => c.Classroom).NotEmpty().MaximumLength(20);
        RuleFor(c => c.StartsAtUtc).NotEmpty().GreaterThan(DateTime.UtcNow);
        RuleFor(c => c.EndsAtUtc)
            .Must((cmd, endTime) => endTime > cmd.StartsAtUtc)
            .WithMessage("End time must be after start time");
        RuleFor(c => c.GroupUid).NotEmpty();
        RuleFor(c => c.TeacherUid).NotEmpty();
    }
}
