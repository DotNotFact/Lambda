using LambdaUI.Models;
using System.Collections.ObjectModel;

namespace LambdaUI.Services;

public class UserService : IUserService
{
    private readonly IRepository<User> _repository;

    public UserService(IRepository<User> repository)
    {
        _repository = repository;
    }

    public User Authenticate(string username, string password)
    {
        return _repository.GetAll().FirstOrDefault(u => u.Username == username && u.PasswordHash == password);
    }

    public bool Register(User user)
    {
        if (_repository.GetAll().Any(u => u.Username == user.Username))
            return false;
        _repository.Add(user);
        return true;
    }

    public ObservableCollection<User> GetAll()
    {
        return _repository.GetAll();
    }

    public void Add(User user)
    {
        _repository.Add(user);
    }

    public void Update(User user)
    {
        _repository.Update(user);
    }

    public void Delete(Guid id)
    {
        _repository.Delete(id);
    }
}
