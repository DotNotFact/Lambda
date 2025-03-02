using Lambda.Modules.Users.Application.Repositories;
using Lambda.Modules.Users.Domain.Entities.Enums;
using Lambda.Modules.Users.Application.Services;
using Microsoft.AspNetCore.Identity;
using Lambda.Modules.Users.Domain.Entities;
using NETCore.MailKit.Core;

namespace Lambda.Modules.Users.Infrastructure.Services;

public class UserService(IUserRepository userRepository, IPasswordHasher<UserEntity> passwordHasher) : IUserService // , IEmailService emailService
{
    private readonly IUserRepository _userRepository = userRepository;
    private readonly IPasswordHasher<UserEntity> _passwordHasher = passwordHasher;
  //  private readonly IEmailService _emailService = emailService;

    public async Task RegisterUserAsync(string username, string email, string password, Role role)
    {
        var existingUser = await _userRepository.GetUserByUsernameAsync(username);
        if (existingUser != null)
            throw new Exception("Username already exists");

        var user = new UserEntity
        {
            Username = username,
            Email = email,
            Role = role
        };

        user.PasswordHash = _passwordHasher.HashPassword(user, password);

        await _userRepository.AddUserAsync(user);
    }

    public async Task<UserEntity> AuthenticateAsync(string username, string password)
    {
        var user = await _userRepository.GetUserByUsernameAsync(username);
        if (user == null)
            return null;

        var result = _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, password);
        return result == PasswordVerificationResult.Success ? user : null;
    }

    public async Task<bool> ChangePasswordAsync(int userId, string currentPassword, string newPassword)
    {
        var user = await _userRepository.GetUserByIdAsync(userId);
        if (user == null)
            return false;

        var result = _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, currentPassword);
        if (result != PasswordVerificationResult.Success)
            return false;

        user.PasswordHash = _passwordHasher.HashPassword(user, newPassword);
        await _userRepository.UpdateUserAsync(user);
        return true;
    }

    public async Task SendPasswordResetEmailAsync(string email)
    {
        var user = await _userRepository.GetUserByEmailAsync(email) 
            ?? throw new Exception("User not found");

        // Generate password reset token
        var token = Guid.NewGuid().ToString();

        // Store token in the database with expiration time
        // ...

        // Send email with the token
        var resetLink = $"https://yourapp.com/reset-password?token={token}";
       //  await _emailService.SendEmailAsync(email, "Password Reset", $"Click the link to reset your password: {resetLink}");
    }
} 