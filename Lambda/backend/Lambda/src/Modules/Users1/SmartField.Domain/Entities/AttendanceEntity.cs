using Lambda.Modules.Users.Domain.Entities.Enums;

namespace Lambda.Modules.Users.Domain.Entities;

public class AttendanceEntity
{
    public Guid Uid { get; set; } // Уникальный идентификатор посещаемости
    public Guid StudentUid { get; set; } // Внешний ключ на Student
    public Guid ScheduleUid { get; set; } // Внешний ключ на Schedule
    public AttendanceStatus Status { get; set; }

    // Navigation properties
    public StudentEntity Student { get; set; }
    public ScheduleEntty Schedule { get; set; }
}