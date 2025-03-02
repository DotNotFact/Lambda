using Lambda.Modules.Users.Domain.Entities;

namespace Lambda.Modules.Users.Application.Repositories;

public interface IStudentRepository
{
    Task<StudentEntity> GetStudentByUidAsync(Guid studentUid);
    Task<IEnumerable<StudentEntity>> GetAllStudentsAsync();
    Task AddStudentAsync(StudentEntity student);
    Task UpdateStudentAsync(StudentEntity student);
    Task DeleteStudentAsync(Guid studentUid);
}
