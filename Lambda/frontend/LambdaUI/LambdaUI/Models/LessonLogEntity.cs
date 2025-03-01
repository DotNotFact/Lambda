namespace LambdaUI.Models;

public class LessonLogDto
{
    public Guid Uid { get; set; } // Уникальный идентификатор журнала занятий
    public Guid ScheduleUid { get; set; } // Внешний ключ на Schedule
    public DateTime LogDate { get; set; }
    public string Notes { get; set; }

    // Navigation properties
    public ScheduleEntty Schedule { get; set; }
}
