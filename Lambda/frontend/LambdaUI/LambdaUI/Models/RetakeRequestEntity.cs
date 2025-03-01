using LambdaUI.Models.Enums;

namespace LambdaUI.Models;

public class RetakeRequestDto
{
    public Guid Uid { get; set; } // Уникальный идентификатор запроса на пересдачу
    public Guid StudentUid { get; set; } // Внешний ключ на Student
    public Guid ScheduleUid { get; set; } // Внешний ключ на Schedule
    public DateTime RequestDate { get; set; }
    public RetakeRequestStatus Status { get; set; }

    // Navigation properties
    public StudentDto Student { get; set; }
    public ScheduleEntty Schedule { get; set; }
}