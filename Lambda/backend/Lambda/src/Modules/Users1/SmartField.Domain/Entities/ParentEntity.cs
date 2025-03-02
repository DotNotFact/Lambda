namespace Lambda.Modules.Users.Domain.Entities;

public class ParentEntity
{
    public Guid Uid { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string ContactInfo { get; set; }
    public string Address { get; set; }

    public UserEntity User { get; set; }

    public ICollection<StudentEntity> Students { get; set; }
}