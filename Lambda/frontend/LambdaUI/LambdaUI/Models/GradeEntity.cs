namespace LambdaUI.Models;

public class GradeDto
{
    public Guid Uid { get; set; } // Уникальный идентификатор оценки
    public Guid StudentUid { get; set; } // Внешний ключ на Student
    public Guid ScheduleUid { get; set; } // Внешний ключ на Schedule
    public int GradeValue { get; set; }
    public DateTime GradeDate { get; set; }

    // Navigation properties
    public StudentDto Student { get; set; }
    public ScheduleEntty Schedule { get; set; }
}