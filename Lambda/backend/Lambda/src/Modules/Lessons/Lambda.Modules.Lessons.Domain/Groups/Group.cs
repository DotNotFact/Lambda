using Lambda.Modules.Lessons.Domain.Lessons;
using Lambda.Modules.Lessons.Domain.Students;
using Lambda.Modules.Lessons.Domain.Teachers;

namespace Lambda.Modules.Lessons.Domain.Groups;

public class Group
{
    public Guid Uid { get; set; }

    public string Name { get; set; }

    public string Title { get; set; } 
    public string Description { get; set; }

    public Teacher Teacher { get; set; }
    public Guid? TeacherUid { get; set; }

    public ICollection<Student> Students { get; set; }
    public ICollection<Lesson> Lessons { get; set; }
}
