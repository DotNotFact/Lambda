﻿namespace LambdaUI.Models;

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
    public GroupDto Group { get; set; }
    public TeacherDto Teacher { get; set; }
    public ICollection<AttendanceDto> Attendances { get; set; }
    public ICollection<GradeDto> Grades { get; set; }
    public ICollection<LessonLogDto> LessonLogs { get; set; }
    public ICollection<RetakeRequestDto> RetakeRequests { get; set; }
}