using Lambda.Modules.Lessons.Domain.Students;
using Lambda.Modules.Lessons.Domain.Lessons;
using System.ComponentModel;

namespace Lambda.Modules.Lessons.Domain.Attendances;

/// <summary>
/// Посещаемость
/// </summary>
public class Attendance
{
    public Guid Uid { get; set; }

    public AttendanceStatus Status { get; set; }

    public Student Student { get; set; }
    public Guid StudentUid { get; set; }

    public Lesson Lesson { get; set; }
    public Guid LessonUid { get; set; }
}

/// <summary>
/// Статус посещаемости
/// </summary>
public enum AttendanceStatus
{
    [Description("Присутствует")]
    Present = 0,
    [Description("Отсутствует")]
    Absent = 1,
    [Description("Опоздал")]
    Late = 2,
}
