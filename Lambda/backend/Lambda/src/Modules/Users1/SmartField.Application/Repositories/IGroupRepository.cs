using Lambda.Modules.Users.Domain.Entities;

namespace Lambda.Modules.Users.Application.Repositories;
 
public interface IGroupRepository
{
    Task<GroupEntity> GetGroupByIdAsync(Guid groupUid);
    Task<IEnumerable<GroupEntity>> GetAllGroupsAsync();
    Task AddGroupAsync(GroupEntity group);
    Task UpdateGroupAsync(GroupEntity group);
    Task DeleteGroupAsync(Guid groupUid);
    Task<IEnumerable<GroupEntity>> GetGroupsByTeacherIdAsync(Guid teacherUid); 
}
