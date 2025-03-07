using LambdaUI.Models.Enums;

namespace LambdaUI.Models;

public class Attendance
{
    public Guid Uid { get; set; } // Уникальный идентификатор посещаемости
    public Guid StudentUid { get; set; } // Внешний ключ на Student
    public Guid ScheduleUid { get; set; } // Внешний ключ на Schedule
    public AttendanceStatus Status { get; set; }

    // Navigation properties
    public Student Student { get; set; }
    public Schedule Schedule { get; set; }
}