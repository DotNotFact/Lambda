using Lambda.Modules.Users.Domain.Entities.Enums;

namespace Lambda.Modules.Users.Domain.Entities;

public class UserEntity
{
    public Guid Uid { get; set; }
    public string Username { get; set; }
    public string PasswordHash { get; set; }
    public string Email { get; set; }
    public Role Role { get; set; }
    public DateTime CreatedAt { get; set; }

    // Navigation properties
    public StudentEntity Student { get; set; }
    public Guid? StudentUid { get; set; }
    public TeacherEntity Teacher { get; set; }
    public Guid? TeacherUid { get; set; }
    public ParentEntity Parent { get; set; }
    public Guid? ParentUid { get; set; }

    public IEnumerable<NotificationEntity> Notifications { get; set; }
}