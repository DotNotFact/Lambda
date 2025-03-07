namespace LambdaUI.Models;

public class Schedule
{
    public Guid Uid { get; set; } // Уникальный идентификатор расписания
    public Guid GroupUid { get; set; } // Внешний ключ на Group
    public Guid TeacherUid { get; set; } // Внешний ключ на Teacher
    public string Subject { get; set; }
    public string Classroom { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }

    // Navigation properties
    public Group Group { get; set; }
    public Teacher Teacher { get; set; }
    public ICollection<Attendance> Attendances { get; set; }
    public ICollection<Grade> Grades { get; set; }
    public ICollection<LessonLog> LessonLogs { get; set; }
    public ICollection<RetakeRequest> RetakeRequests { get; set; }
}