using Lambda.Modules.Users.Application.Repositories;
using Lambda.Modules.Users.Infrastructure.DataBase;
using Microsoft.EntityFrameworkCore;
using Lambda.Modules.Users.Domain.Entities;

namespace Lambda.Modules.Users.Infrastructure.Services;

public class StudentRepository(LambdaDbContext context) : IStudentRepository
{
    private readonly LambdaDbContext _context = context;

    public async Task<StudentEntity> GetStudentByUidAsync(Guid studentUid)
    {
        return await _context.Students
            .Include(s => s.User)
            .Include(s => s.Parent)
            .FirstOrDefaultAsync(s => s.Uid == studentUid);
    }

    public async Task<IEnumerable<StudentEntity>> GetAllStudentsAsync()
    {
        return await _context.Students
            .Include(s => s.User)
            .Include(s => s.Parent)
            .ToListAsync();
    }

    public async Task AddStudentAsync(StudentEntity student)
    {
        await _context.Students.AddAsync(student);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateStudentAsync(StudentEntity student)
    {
        _context.Students.Update(student);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteStudentAsync(Guid studentUid)
    {
        var student = await _context.Students.FindAsync(studentUid);
        if (student != null)
        {
            _context.Students.Remove(student);
            await _context.SaveChangesAsync();
        }
    }
}
