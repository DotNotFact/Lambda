using Lambda.Modules.Users.Domain.Entities;
using Lambda.Modules.Users.Domain.Entities.Enums;

namespace Lambda.Modules.Users.Application.Services;

public interface IUserService
{
    Task RegisterUserAsync(string username, string email, string password, Role role);
    Task<UserEntity> AuthenticateAsync(string username, string password);
    Task<bool> ChangePasswordAsync(int userId, string currentPassword, string newPassword);
    Task SendPasswordResetEmailAsync(string email);
}