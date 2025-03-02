using Lambda.Modules.Users.Application.Repositories;
using Lambda.Modules.Users.Application.Services;
using Lambda.Modules.Users.Domain.Entities;

namespace Lambda.Modules.Users.Infrastructure.Services;

public class GroupService(IGroupRepository groupRepository) : IGroupService
{
    private readonly IGroupRepository _groupRepository = groupRepository;

    public async Task CreateGroupAsync(GroupEntity group)
    {
        await _groupRepository.AddGroupAsync(group);
    }

    public async Task UpdateGroupAsync(GroupEntity group)
    {
        await _groupRepository.UpdateGroupAsync(group);
    }

    public async Task DeleteGroupAsync(Guid groupUid)
    {
        await _groupRepository.DeleteGroupAsync(groupUid);
    }

    public async Task<GroupEntity> GetGroupByIdAsync(Guid groupUid)
    {
        return await _groupRepository.GetGroupByIdAsync(groupUid);
    }

    public async Task<IEnumerable<GroupEntity>> GetAllGroupsAsync()
    {
        return await _groupRepository.GetAllGroupsAsync();
    }

    public async Task<IEnumerable<GroupEntity>> GetGroupsByTeacherIdAsync(Guid teacherUid)
    {
        return await _groupRepository.GetGroupsByTeacherIdAsync(teacherUid);
    }

    // Additional methods...
}