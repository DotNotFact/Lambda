namespace LambdaUI.Models;

public class LessonLog
{
    public Guid Uid { get; set; } // Уникальный идентификатор журнала занятий
    public Guid ScheduleUid { get; set; } // Внешний ключ на Schedule
    public DateTime LogDate { get; set; }
    public string Notes { get; set; }

    // Navigation properties
    public Schedule Schedule { get; set; }
}
