namespace Lambda.Modules.Users.Domain.Entities;

public class StudentEntity
{
    public Guid Uid { get; set; } // Уникальный идентификатор студента
    public Guid UserUid { get; set; } // Внешний ключ на User
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public string FullName => $"{FirstName} {LastName}";

    public DateTime? BirthDate { get; set; }
    public string ContactInfo { get; set; }
    public string Address { get; set; }
    public Guid? ParentUid { get; set; } // Внешний ключ на Parent

    // Navigation properties
    public UserEntity User { get; set; }
    public ParentEntity Parent { get; set; }
    public ICollection<GroupStudentEntity> GroupStudents { get; set; }
    public ICollection<AttendanceEntity> Attendances { get; set; }
    public ICollection<GradeEntity> Grades { get; set; }
    public ICollection<RetakeRequestEntity> RetakeRequests { get; set; }
    public ICollection<DocumentEntity> Documents { get; set; }
    public ICollection<FinancialDataEntity> FinancialData { get; set; }
}