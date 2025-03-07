namespace LambdaUI.Models;

public class Grade
{
    public Guid Uid { get; set; } // Уникальный идентификатор оценки
    public Guid StudentUid { get; set; } // Внешний ключ на Student
    public Guid ScheduleUid { get; set; } // Внешний ключ на Schedule
    public int GradeValue { get; set; }
    public DateTime GradeDate { get; set; }

    // Navigation properties
    public Student Student { get; set; }
    public Schedule Schedule { get; set; }
}