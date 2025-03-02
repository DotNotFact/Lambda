using Lambda.Modules.Users.Domain.Entities;

namespace Lambda.Modules.Users.Application.Services;

public interface IGroupService
{
    Task CreateGroupAsync(GroupEntity group);
    Task UpdateGroupAsync(GroupEntity group);
    Task DeleteGroupAsync(Guid groupUid);
    Task<GroupEntity> GetGroupByIdAsync(Guid groupUid);
    Task<IEnumerable<GroupEntity>> GetAllGroupsAsync();
    Task<IEnumerable<GroupEntity>> GetGroupsByTeacherIdAsync(Guid teacherUid);
}