using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using LambdaUI.Models;
using LambdaUI.Models.Enums;
using LambdaUI.Services;
using LambdaUI.ViewModels.Windows;
using System.Collections.ObjectModel; 
using System.Windows.Input;

namespace LambdaUI.ViewModels.Pages;

public partial class AdministrationViewModel : ObservableObject
{
    private readonly IUserService _userService;

    public ICommand AddUserCommand { get; }
    public ICommand EditUserCommand { get; }
    public ICommand DeleteUserCommand { get; }

    public ObservableCollection<User> Users { get; set; }

    private string _searchQuery;
    public string SearchQuery
    {
        get => _searchQuery;
        set => SetProperty(ref _searchQuery, value);
    }

    private User _selectedUser;
    public User SelectedUser
    {
        get => _selectedUser;
        set => SetProperty(ref _selectedUser, value);
    }

    public AdministrationViewModel(IUserService userService)
    {
        _userService = userService;
        AddUserCommand = new RelayCommand(AddUser);
        EditUserCommand = new RelayCommand(EditUser);
        DeleteUserCommand = new RelayCommand(DeleteUser);
        Users = _userService.GetAll();
        Roles = new ObservableCollection<Role>
        {
            Role.Student,
            Role.Teacher,
            Role.Administrator,
            Role.Director,
            Role.Parent
        };
    }

    public ObservableCollection<Role> Roles { get; set; }

    private void AddUser()
    {
        var user = new User
        {
            Uid = Guid.NewGuid(),
            Username = "newuser",
            PasswordHash = "password",
            Role = Role.Student,
            Email = "newuser@example.com",
            CreatedAt = DateTime.Now
        };
        _userService.Add(user);
        Users = _userService.GetAll();
    }

    private void EditUser()
    {
        if (SelectedUser != null)
        {
            // TODO: Реализовать редактирование пользователя
            _userService.Update(SelectedUser);
            Users = _userService.GetAll();
        }
    }

    private void DeleteUser()
    {
        if (SelectedUser != null)
        {
            _userService.Delete(SelectedUser.Uid);
            Users = _userService.GetAll();
        }
    } 
    // Аналогично реализовать другие ViewModels: StudentViewModel, GroupViewModel, ScheduleViewModel и т.д.
}  