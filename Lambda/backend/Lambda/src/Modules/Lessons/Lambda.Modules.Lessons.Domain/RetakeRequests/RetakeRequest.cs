using Lambda.Modules.Lessons.Domain.Students;
using Lambda.Modules.Lessons.Domain.Lessons;
using System.ComponentModel;

namespace Lambda.Modules.Lessons.Domain.RetakeRequests;

/// <summary>
/// Запрос на пересдачу
/// </summary>
public class RetakeRequest
{
    public Guid Uid { get; set; }

    public DateTime RequestDate { get; set; }
    public RetakeRequestStatus Status { get; set; }

    public Student Student { get; set; }
    public Guid StudentUid { get; set; }

    public Lesson Lesson { get; set; }
    public Guid LessonUid { get; set; }
}

public enum RetakeRequestStatus
{
    [Description("Ожидаемый")]
    Pending,
    [Description("Одобренный")]
    Approved,
    [Description("Отклоненный")]
    Rejected,
}
