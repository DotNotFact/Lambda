namespace Lambda.Modules.Lessons.Application.Lessons.GetLesson;

public sealed record LessonResponse(
    Guid Uid,
    string Subject,
    string Description,
    string Classroom,
    DateTime StartTime,
    DateTime EndTime,
    Guid GroupUid,
    Guid TeacherUid);
