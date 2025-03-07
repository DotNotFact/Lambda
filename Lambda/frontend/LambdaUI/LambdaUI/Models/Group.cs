namespace LambdaUI.Models;

public class Group
{
    public Guid Uid { get; set; } // Уникальный идентификатор группы
    public string Name { get; set; }
    public Guid? TeacherUid { get; set; } // Внешний ключ на Teacher

    // Navigation properties
    public Teacher Teacher { get; set; }
    public ICollection<GroupStudent> GroupStudents { get; set; }
    public ICollection<Schedule> Schedules { get; set; }
}
