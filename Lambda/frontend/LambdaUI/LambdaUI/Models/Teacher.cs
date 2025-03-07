namespace LambdaUI.Models;

public class Teacher
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
    public User User { get; set; }
    public ICollection<Group> Groups { get; set; }
    public ICollection<Schedule> Schedules { get; set; }
    public ICollection<LearningMaterial> LearningMaterials { get; set; }
    public ICollection<LessonLog> LessonLogs { get; set; }
}
