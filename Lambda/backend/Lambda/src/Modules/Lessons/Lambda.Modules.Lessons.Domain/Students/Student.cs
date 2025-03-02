using Lambda.Modules.Lessons.Domain.Grades;
using Lambda.Modules.Lessons.Domain.Parents;
using Lambda.Modules.Lessons.Domain.RetakeRequests; 
using Lambda.Modules.Lessons.Domain.Attendances;

namespace Lambda.Modules.Lessons.Domain.Students;

public class Student
{
    public Guid Uid { get; set; } 

    public string FirstName { get; set; }
    public string LastName { get; set; }

    public string FullName => $"{FirstName} {LastName}";

    public DateTime? BirthDate { get; set; }

    public string ContactInfo { get; set; }
    public string Address { get; set; }
     
    // public UserEntity User { get; set; }
    // public Guid UserUid { get; set; }

    public Parent Parent { get; set; }
    public Guid? ParentUid { get; set; }
     
    public ICollection<Attendance> Attendances { get; set; }
    public ICollection<Grade> Grades { get; set; }
    public ICollection<RetakeRequest> RetakeRequests { get; set; }

    // public ICollection<Document> Documents { get; set; }
    // public ICollection<FinancialData> FinancialData { get; set; }
}
