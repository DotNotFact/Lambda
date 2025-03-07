using LambdaUI.Models;

namespace LambdaUI.Services;

public class AuthenticationService
{
    public bool Authenticate(string username, string password)
    {
        var user = LocalStorageService.GetCollection<User>().FirstOrDefault(u => u.Username == username);
        if (user != null && user.PasswordHash == password) // TODO: Хэширование паролей
        {
            // TODO: Установка сессии
            return true;
        }
        return false;
    }

    public bool Register(User user)
    {
        var users = LocalStorageService.GetCollection<User>();
        if (users.Any(u => u.Username == user.Username))
            return false;
        users.Add(user);
        LocalStorageService.SaveChanges();
        return true;
    }
}