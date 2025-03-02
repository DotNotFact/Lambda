using Microsoft.EntityFrameworkCore;
using Lambda.Modules.Users.Application.Repositories;
using Lambda.Modules.Users.Domain.Entities;
using Lambda.Modules.Users.Infrastructure.DataBase;

namespace Lambda.Modules.Users.Infrastructure.Services;

public class TeacherRepository(LambdaDbContext context) : ITeacherRepository
{
    private readonly LambdaDbContext _context = context;

    public async Task<TeacherEntity> GetTeacherByIdAsync(Guid teacherUid)
    {
        return await _context.Teachers
            .Include(t => t.User)
            .Include(t => t.Groups)
            .Include(t => t.Schedules)
            .Include(t => t.LearningMaterials)
            .Include(t => t.LessonLogs)
            .FirstOrDefaultAsync(t => t.Uid == teacherUid);
    }

    public async Task<IEnumerable<TeacherEntity>> GetAllTeachersAsync()
    {
        return await _context.Teachers
            .Include(t => t.User)
            .Include(t => t.Groups)
            .Include(t => t.Schedules)
            .Include(t => t.LearningMaterials)
            .Include(t => t.LessonLogs)
            .ToListAsync();
    }

    public async Task AddTeacherAsync(TeacherEntity teacher)
    {
        await _context.Teachers.AddAsync(teacher);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateTeacherAsync(TeacherEntity teacher)
    {
        _context.Teachers.Update(teacher);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteTeacherAsync(Guid teacherUid)
    {
        var teacher = await _context.Teachers.FindAsync(teacherUid);
        if (teacher != null)
        {
            _context.Teachers.Remove(teacher);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<IEnumerable<TeacherEntity>> GetTeachersByDepartmentAsync(string department)
    {
        return await _context.Teachers
            .Where(t => t.Department == department)
            .Include(t => t.User)
            .Include(t => t.Groups)
            .Include(t => t.Schedules)
            .Include(t => t.LearningMaterials)
            .Include(t => t.LessonLogs)
            .ToListAsync();
    }

    // Additional methods...
}
