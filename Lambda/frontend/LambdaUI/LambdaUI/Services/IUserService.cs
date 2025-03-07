using LambdaUI.Models;
using System.Collections.ObjectModel;

namespace LambdaUI.Services;

public interface IUserService
{
    User Authenticate(string username, string password);
    bool Register(User user);
    ObservableCollection<User> GetAll();
    void Add(User user);
    void Update(User user);
    void Delete(Guid id);
}
