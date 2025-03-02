using Lambda.Modules.Lessons.Domain.RetakeRequests;
using Lambda.Modules.Lessons.Domain.Attendances;
using Lambda.Modules.Lessons.Domain.Teachers;
using Lambda.Modules.Lessons.Domain.Grades;
using Lambda.Modules.Lessons.Domain.Groups;
using Lambda.Common.Domain;

namespace Lambda.Modules.Lessons.Domain.Lessons;

/// <summary>
/// Урок
/// </summary>
public class Lesson : Entity
{
    public Guid Uid { get; set; }

    public DateTime StartsAtUtc { get; set; }
    public DateTime EndsAtUtc { get; set; }

    public string Subject { get; set; } // todo: podv. перенести предмет в сущность
    public string Classroom { get; set; } // todo: podv. перенести кабинет в сущность?

    public string Description { get; set; }

    // public Group Group { get; set; }
    public Guid GroupUid { get; set; }

    // public Teacher Teacher { get; set; }
    public Guid TeacherUid { get; set; }

    //public ICollection<Attendance> Attendances { get; set; }
    //public ICollection<Grade> Grades { get; set; }

    //public ICollection<RetakeRequest> RetakeRequests { get; set; }


    // Исправленный метод Create в Lesson
    public static Lesson Create(
        string subject,
        string description,
        string classroom,
        DateTime startsAtUtc,
        DateTime endsAtUtc,
        Guid groupUid,
        Guid teacherUid)
    {
        var lesson = new Lesson
        {
            Uid = Guid.NewGuid(),
            Subject = subject,
            Description = description,
            Classroom = classroom,
            StartsAtUtc = startsAtUtc,
            EndsAtUtc = endsAtUtc,
            GroupUid = groupUid,
            TeacherUid = teacherUid
        };

        lesson.Raise(new LessonCreatedDomainEvent(lesson.Uid));
        return lesson;
    }
}
