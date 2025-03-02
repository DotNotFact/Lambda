using Microsoft.EntityFrameworkCore;
using Lambda.Modules.Users.Application.Repositories;
using Lambda.Modules.Users.Domain.Entities;
using Lambda.Modules.Users.Infrastructure.DataBase;

namespace Lambda.Modules.Users.Infrastructure.Services;

public class GroupRepository(LambdaDbContext context) : IGroupRepository
{
    private readonly LambdaDbContext _context = context;

    public async Task<GroupEntity> GetGroupByIdAsync(Guid groupUid)
    {
        return await _context.Groups
            .Include(g => g.Teacher)
            .Include(g => g.GroupStudents)
                .ThenInclude(gs => gs.Student)
            .FirstOrDefaultAsync(g => g.Uid == groupUid);
    }

    public async Task<IEnumerable<GroupEntity>> GetAllGroupsAsync()
    {
        return await _context.Groups
            .Include(g => g.Teacher)
            .Include(g => g.GroupStudents)
                .ThenInclude(gs => gs.Student)
            .ToListAsync();
    }

    public async Task AddGroupAsync(GroupEntity group)
    {
        await _context.Groups.AddAsync(group);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateGroupAsync(GroupEntity group)
    {
        _context.Groups.Update(group);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteGroupAsync(Guid groupUid)
    {
        var group = await _context.Groups
            .FirstOrDefaultAsync(x => x.Uid == groupUid);

        if (group != null)
        {
            _context.Groups.Remove(group);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<IEnumerable<GroupEntity>> GetGroupsByTeacherIdAsync(Guid teacherUid)
    {
        return await _context.Groups
            .Where(g => g.TeacherUid == teacherUid)
            .Include(g => g.Teacher)
            .Include(g => g.GroupStudents)
                .ThenInclude(gs => gs.Student)
            .ToListAsync();
    }

    // Additional methods...
}
