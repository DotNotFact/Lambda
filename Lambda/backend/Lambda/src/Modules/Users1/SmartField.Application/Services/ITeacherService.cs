using Lambda.Modules.Users.Domain.Entities;

namespace Lambda.Modules.Users.Application.Services;

public interface ITeacherService
{
    Task CreateTeacherAsync(TeacherEntity teacher);
    Task UpdateTeacherAsync(TeacherEntity teacher);
    Task DeleteTeacherAsync(Guid teacherUid);
    Task<TeacherEntity> GetTeacherByIdAsync(Guid teacherUid);
    Task<IEnumerable<TeacherEntity>> GetAllTeachersAsync();
    Task<IEnumerable<TeacherEntity>> GetTeachersByDepartmentAsync(string department);
}
