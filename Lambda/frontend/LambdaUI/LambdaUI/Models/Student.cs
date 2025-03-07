namespace LambdaUI.Models;

public class Student
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
    public User User { get; set; }
    public Parent Parent { get; set; }
    public ICollection<GroupStudent> GroupStudents { get; set; }
    public ICollection<Attendance> Attendances { get; set; }
    public ICollection<Grade> Grades { get; set; }
    public ICollection<RetakeRequest> RetakeRequests { get; set; }
    public ICollection<Document> Documents { get; set; }
    public ICollection<FinancialData> FinancialData { get; set; }
}