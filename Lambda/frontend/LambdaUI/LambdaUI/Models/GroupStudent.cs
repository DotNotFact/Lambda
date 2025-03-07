namespace LambdaUI.Models;

public class GroupStudent
{
    public Guid GroupUid { get; set; } // Внешний ключ на Group
    public Guid StudentUid { get; set; } // Внешний ключ на Student

    // Navigation properties
    public Group Group { get; set; }
    public Student Student { get; set; }
}