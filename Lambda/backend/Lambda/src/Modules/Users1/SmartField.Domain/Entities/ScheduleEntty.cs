namespace Lambda.Modules.Users.Domain.Entities;

public class ScheduleEntty
{
    public Guid Uid { get; set; } // Уникальный идентификатор расписания
    public Guid GroupUid { get; set; } // Внешний ключ на Group
    public Guid TeacherUid { get; set; } // Внешний ключ на Teacher
    public string Subject { get; set; }
    public string Classroom { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }

    // Navigation properties
    public GroupEntity Group { get; set; }
    public TeacherEntity Teacher { get; set; }
    public ICollection<AttendanceEntity> Attendances { get; set; }
    public ICollection<GradeEntity> Grades { get; set; }
    public ICollection<LessonLogEntity> LessonLogs { get; set; }
    public ICollection<RetakeRequestEntity> RetakeRequests { get; set; }
}