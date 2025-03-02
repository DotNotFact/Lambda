namespace Lambda.Modules.Users.Domain.Entities;

public class GroupEntity
{
    public Guid Uid { get; set; } // Уникальный идентификатор группы
    public string Name { get; set; }
    public Guid? TeacherUid { get; set; } // Внешний ключ на Teacher

    // Navigation properties
    public TeacherEntity Teacher { get; set; }
    public ICollection<GroupStudentEntity> GroupStudents { get; set; }
    public ICollection<ScheduleEntty> Schedules { get; set; }
}
