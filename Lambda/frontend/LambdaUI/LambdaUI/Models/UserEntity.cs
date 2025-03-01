using LambdaUI.Models.Enums;

namespace LambdaUI.Models;

public class UserDto
{
    public Guid Uid { get; set; }
    public string Username { get; set; }
    public string PasswordHash { get; set; }
    public string Email { get; set; }
    public Role Role { get; set; }
    public DateTime CreatedAt { get; set; }

    // Navigation properties
    public StudentDto Student { get; set; }
    public Guid? StudentUid { get; set; }
    public TeacherDto Teacher { get; set; }
    public Guid? TeacherUid { get; set; }
    public ParentDto Parent { get; set; }
    public Guid? ParentUid { get; set; }

    public IEnumerable<NotificationDto> Notifications { get; set; }
}