﻿using Lambda.Modules.Lessons.Domain.Students;
using Lambda.Modules.Lessons.Domain.Lessons;

namespace Lambda.Modules.Lessons.Domain.Grades;

/// <summary>
/// Оценка
/// </summary>
public class Grade
{
    public Guid Uid { get; set; }

    public int GradeValue { get; set; }
    public DateTime GradeDate { get; set; }

    public Student Student { get; set; }
    public Guid StudentUid { get; set; }

    public Lesson Lesson { get; set; }
    public Guid LessonUid { get; set; }
}
