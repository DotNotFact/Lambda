namespace LambdaUI.Models;

public class GroupDto
{
    public Guid Uid { get; set; } // Уникальный идентификатор группы
    public string Name { get; set; }
    public Guid? TeacherUid { get; set; } // Внешний ключ на Teacher

    // Navigation properties
    public TeacherDto Teacher { get; set; }
    public ICollection<GroupStudentDto> GroupStudents { get; set; }
    public ICollection<ScheduleEntty> Schedules { get; set; }
}
