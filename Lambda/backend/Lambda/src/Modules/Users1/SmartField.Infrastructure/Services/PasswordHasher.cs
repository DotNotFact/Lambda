using Microsoft.AspNetCore.Identity;
using System.Security.Cryptography;
using Lambda.Modules.Users.Domain.Entities;
using System.Text;

namespace Lambda.Modules.Users.Infrastructure.Services;
 
public class PasswordHasher : IPasswordHasher<UserEntity>
{
    public string HashPassword(UserEntity user, string password)
    {
        if (string.IsNullOrEmpty(password))
            throw new ArgumentException("Password cannot be null or empty", nameof(password));
        
        var bytes = SHA256.HashData(Encoding.UTF8.GetBytes(password));
      
        return Convert.ToBase64String(bytes);
    }

    public PasswordVerificationResult VerifyHashedPassword(UserEntity user, string hashedPassword, string providedPassword)
    {
        var hashOfProvidedPassword = HashPassword(user, providedPassword);
        
        if (string.Equals(hashedPassword, hashOfProvidedPassword, StringComparison.Ordinal))
            return PasswordVerificationResult.Success;
        
        return PasswordVerificationResult.Failed;
    }
}