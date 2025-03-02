using Lambda.Modules.Users.Domain.Entities;

namespace Lambda.Modules.Users.Application.Repositories;

public interface IUserRepository
{
    Task<UserEntity> GetUserByIdAsync(int userId);
    Task<UserEntity> GetUserByUsernameAsync(string username);
    Task<UserEntity> GetUserByEmailAsync(string email);
    Task<IEnumerable<UserEntity>> GetAllUsersAsync();
    Task AddUserAsync(UserEntity user);
    Task UpdateUserAsync(UserEntity user);
    Task DeleteUserAsync(int userId);
}
