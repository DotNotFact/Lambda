namespace LambdaUI.Models;

public class StudentDto
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
    public UserDto User { get; set; }
    public ParentDto Parent { get; set; }
    public ICollection<GroupStudentDto> GroupStudents { get; set; }
    public ICollection<AttendanceDto> Attendances { get; set; }
    public ICollection<GradeDto> Grades { get; set; }
    public ICollection<RetakeRequestDto> RetakeRequests { get; set; }
    public ICollection<DocumentDto> Documents { get; set; }
    public ICollection<FinancialDataDto> FinancialData { get; set; }
}