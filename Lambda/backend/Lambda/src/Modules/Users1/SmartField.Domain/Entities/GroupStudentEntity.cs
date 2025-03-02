namespace Lambda.Modules.Users.Domain.Entities;

public class GroupStudentEntity
{
    public Guid GroupUid { get; set; } // Внешний ключ на Group
    public Guid StudentUid { get; set; } // Внешний ключ на Student

    // Navigation properties
    public GroupEntity Group { get; set; }
    public StudentEntity Student { get; set; }
}