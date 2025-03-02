using Lambda.Modules.Lessons.Domain.Students;

namespace Lambda.Modules.Lessons.Domain.Parents;

public class Parent
{
    public Guid Uid { get; set; }

    public string FirstName { get; set; }
    public string LastName { get; set; }

    public string ContactInfo { get; set; }
    public string Address { get; set; }

    // public User User { get; set; }

    public ICollection<Student> Students { get; set; }
}
