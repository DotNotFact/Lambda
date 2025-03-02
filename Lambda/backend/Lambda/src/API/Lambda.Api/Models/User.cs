namespace Lambda.Api.Models;

internal class User
{
    public Guid Uid { get; set; }

    public string Username { get; set; }
    public string PasswordHash { get; set; }
    public string Email { get; set; }

    public UserRole Role { get; set; }

    public DateTime CreatedAt { get; set; }

    // public Student Student { get; set; }
    // public Guid? StudentUid { get; set; }
       
    // public Teacher Teacher { get; set; }
    // public Guid? TeacherUid { get; set; }
       
    // public Parent Parent { get; set; }
    // public Guid? ParentUid { get; set; }

    public IEnumerable<Notification> Notifications { get; set; }
}

internal enum UserRole
{
    Parent,
    Student,
    Teacher,
    AssociateDirector,
    Director,
    Admin,
}
