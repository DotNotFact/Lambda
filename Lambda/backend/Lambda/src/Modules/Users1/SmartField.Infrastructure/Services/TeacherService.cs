using Lambda.Modules.Users.Application.Services;
using Lambda.Modules.Users.Domain.Entities;
using Lambda.Modules.Users.Application.Repositories;

namespace Lambda.Modules.Users.Infrastructure.Services;

public class TeacherService(ITeacherRepository teacherRepository) : ITeacherService
{
    private readonly ITeacherRepository _teacherRepository = teacherRepository;

    public async Task CreateTeacherAsync(TeacherEntity teacher)
    {
        await _teacherRepository.AddTeacherAsync(teacher);
    }

    public async Task UpdateTeacherAsync(TeacherEntity teacher)
    {
        await _teacherRepository.UpdateTeacherAsync(teacher);
    }

    public async Task DeleteTeacherAsync(Guid teacherUid)
    {
        await _teacherRepository.DeleteTeacherAsync(teacherUid);
    }

    public async Task<TeacherEntity> GetTeacherByIdAsync(Guid teacherUid)
    {
        return await _teacherRepository.GetTeacherByIdAsync(teacherUid);
    }

    public async Task<IEnumerable<TeacherEntity>> GetAllTeachersAsync()
    {
        return await _teacherRepository.GetAllTeachersAsync();
    }

    public async Task<IEnumerable<TeacherEntity>> GetTeachersByDepartmentAsync(string department)
    {
        return await _teacherRepository.GetTeachersByDepartmentAsync(department);
    }

    // Additional methods...
}