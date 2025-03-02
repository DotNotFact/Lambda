using Lambda.Modules.Users.Domain.Entities;

namespace Lambda.Modules.Users.Application.Repositories;
 
public interface ITeacherRepository
{
    Task<TeacherEntity> GetTeacherByIdAsync(Guid teacherUid);
    Task<IEnumerable<TeacherEntity>> GetAllTeachersAsync();
    Task AddTeacherAsync(TeacherEntity teacher);
    Task UpdateTeacherAsync(TeacherEntity teacher);
    Task DeleteTeacherAsync(Guid teacherUid);
    Task<IEnumerable<TeacherEntity>> GetTeachersByDepartmentAsync(string department);
}
