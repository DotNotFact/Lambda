namespace Lambda.Modules.Users.Domain.Entities;

public class TeacherEntity
{
    public Guid Uid { get; set; } // Уникальный идентификатор преподавателя
    public Guid UserUid { get; set; } // Внешний ключ на User
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public string FullName => $"{FirstName} {LastName}";

    public string ContactInfo { get; set; }
    public string Address { get; set; }
    public string Department { get; set; }

    // Navigation properties
    public UserEntity User { get; set; }
    public ICollection<GroupEntity> Groups { get; set; }
    public ICollection<ScheduleEntty> Schedules { get; set; }
    public ICollection<LearningMaterialEntity> LearningMaterials { get; set; }
    public ICollection<LessonLogEntity> LessonLogs { get; set; }
}
