namespace LambdaUI.Models;

public class GroupStudentDto
{
    public Guid GroupUid { get; set; } // Внешний ключ на Group
    public Guid StudentUid { get; set; } // Внешний ключ на Student

    // Navigation properties
    public GroupDto Group { get; set; }
    public StudentDto Student { get; set; }
}