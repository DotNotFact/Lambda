namespace LambdaUI.Models;

public class TeacherDto
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
    public UserDto User { get; set; }
    public ICollection<GroupDto> Groups { get; set; }
    public ICollection<ScheduleEntty> Schedules { get; set; }
    public ICollection<LearningMaterialDto> LearningMaterials { get; set; }
    public ICollection<LessonLogDto> LessonLogs { get; set; }
}
