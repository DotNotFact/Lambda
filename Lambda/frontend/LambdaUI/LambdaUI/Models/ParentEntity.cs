namespace LambdaUI.Models;

public class ParentDto
{
    public Guid Uid { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string ContactInfo { get; set; }
    public string Address { get; set; }

    public UserDto User { get; set; }

    public ICollection<StudentDto> Students { get; set; }
}