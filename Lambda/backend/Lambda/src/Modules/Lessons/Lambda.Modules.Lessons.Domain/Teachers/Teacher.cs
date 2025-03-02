using Lambda.Modules.Lessons.Domain.Lessons;
using Lambda.Modules.Lessons.Domain.Groups;

namespace Lambda.Modules.Lessons.Domain.Teachers;

public class Teacher
{
    public Guid Uid { get; set; } 

    public string FirstName { get; set; }
    public string LastName { get; set; }

    public string FullName => $"{FirstName} {LastName}";

    public DateTime? BirthDate { get; set; }

    public string ContactInfo { get; set; }
    public string Address { get; set; }
     
    // public UserEntity User { get; set; }
    // public Guid UserUid { get; set; }

    public ICollection<Group> Groups { get; set; }
    public ICollection<Lesson> Lessons { get; set; }  
}
