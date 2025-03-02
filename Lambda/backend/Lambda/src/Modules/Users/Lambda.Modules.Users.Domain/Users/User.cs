 
namespace Lambda.Modules.Users.Domain.Users;

//public class User : Entity
//{
//    public Guid Id { get; } = Guid.NewGuid();
//    public PersonalInfo Info { get; private set; }

//    private readonly List<Role> _roles = [];
//    public IReadOnlyCollection<Role> Roles => _roles.AsReadOnly();

//    // Audit
//    public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;
//    public DateTime ModifiedAt { get; private set; }

//    // Value objects
//    public record PersonalInfo(string FirstName, string LastName, Email Email, PhoneNumber Phone);
//}

//public abstract class Role : Entity
//{
//    public Guid UserId { get; private set; }
//    public User User { get; private set; }
//    public abstract string Type { get; }
//}

//public class StudentRole : Role
//{
//    public override string Type => "Student";
//    public AcademicGroup Group { get; private set; }
//    public ParentRole? Parent { get; private set; }
//}

//public class TeacherRole : Role
//{
//    public override string Type => "Teacher";
//    public Department Department { get; private set; }
//    public List<Course> Courses { get; } = new();
//}


//// Value Objects
//public record Email(string Value);
//public record PhoneNumber(string Value);




//// Образовательные сущности:


//public class AcademicGroup : Entity
//{
//    public string Name { get; private set; }
//    public List<StudentRole> Students { get; } = new();
//    public Schedule Schedule { get; private set; }
//}

//public class Assessment : Entity
//{
//    public enum WorkType { Exam, Test, Project }

//    public Guid StudentId { get; private set; }
//    public WorkType Type { get; private set; }
//    public decimal Score { get; private set; }
//    public DateTime Date { get; private set; }
//}

//public class Attendance : Entity
//{
//    public Guid StudentId { get; private set; }
//    public DateTime Date { get; private set; }
//    public bool IsPresent { get; private set; }
//}

//public class StudyMaterial : Entity
//{
//    public Guid Id { get; } = Guid.NewGuid();
//    private readonly List<MaterialVersion> _versions = new();

//    public string Title { get; private set; }
//    public IReadOnlyCollection<MaterialVersion> Versions => _versions.AsReadOnly();

//    public void AddVersion(string content, DateTime createdAt)
//    {
//        _versions.Add(new MaterialVersion(content, createdAt));
//        Raise(new MaterialUpdatedEvent(Id));
//    }
//}

//public record MaterialVersion(string Content, DateTime CreatedAt  );

//// В модуль Users.Domain
//public class Course : Entity
//{
//    public string Title { get; private set; }
//    public string Code { get; private set; }
//    public Guid DepartmentId { get; private set; }
//}

//public class Department : Entity
//{
//    public string Name { get; private set; }
//    public List<TeacherRole> Teachers { get; } = new();
//}

//public class Schedule : ValueObject
//{
//    public DateTime StartDate { get; }
//    public DateTime EndDate { get; }
//    public RecurrencePattern Recurrence { get; }

//    protected override IEnumerable<object> GetEqualityComponents()
//    {
//        yield return StartDate;
//        yield return EndDate;
//        yield return Recurrence;
//    }
//}

//public class ParentRole : Role
//{
//    public override string Type => "Parent";
//    public List<StudentRole> Children { get; } = new();
//}

//// В модуль Materials.Domain
//public class MaterialUpdatedEvent : DomainEvent
//{
//    public Guid MaterialId { get; }

//    public MaterialUpdatedEvent(Guid materialId)
//    {
//        MaterialId = materialId;
//    }
//}

// Доменные события и UoW:

//public class GradeChangedEvent : DomainEvent
//{
//    public Guid StudentId { get; }
//    public decimal NewGrade { get; }

//    public GradeChangedEvent(Guid studentId, decimal newGrade)
//    {
//        StudentId = studentId;
//        NewGrade = newGrade;
//    }
//}

//public class UnitOfWork : IUnitOfWork
//{
//    private readonly DbContext _context;
//    private readonly IEventDispatcher _dispatcher;

//    public async Task CommitAsync()
//    {
//        await _context.SaveChangesAsync();

//        foreach (var entity in _context.ChangeTracker.Entries<Entity>())
//        {
//            foreach (var domainEvent in entity.Entity.DomainEvents)
//            {
//                await _dispatcher.PublishAsync(domainEvent);
//            }
//            entity.Entity.ClearDomainEvents();
//        }
//    }
//}


// Конфигурация EF Core:

//public class UserConfiguration : IEntityTypeConfiguration<User>
//{
//    public void Configure(EntityTypeBuilder<User> builder)
//    {
//        builder.OwnsOne(u => u.Info, info =>
//        {
//            info.Property(i => i.FirstName).HasMaxLength(100);
//            info.Property(i => i.LastName).HasMaxLength(100);
//            info.OwnsOne(i => i.Email);
//            info.OwnsOne(i => i.Phone);
//        });

//        builder.HasIndex(u => u.Info.Email).IsUnique();
//        builder.HasQueryFilter(u => !u.IsDeleted);
//    }
//}

//public class RoleConfiguration : IEntityTypeConfiguration<Role>
//{
//    public void Configure(EntityTypeBuilder<Role> builder)
//    {
//        builder.HasDiscriminator<string>("RoleType")
//            .HasValue<StudentRole>("Student")
//            .HasValue<TeacherRole>("Teacher");
//    }
//}

// Система прав доступа:

//public class PermissionService
//{
//    public bool HasAccess(User user, string permission)
//    {
//        return user.Roles.Any(r => r.Claims
//            .Any(c => c.Type == permission && c.IsEnabled));
//    }
//}

//public class RoleClaim : ValueObject
//{
//    public string Type { get; }
//    public string Value { get; }
//    public bool IsEnabled { get; private set; }

//    protected override IEnumerable<object> GetEqualityComponents()
//    {
//        yield return Type;
//        yield return Value;
//    }
//}



