using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using LambdaUI.Models;
using LambdaUI.Models.Enums;
using LambdaUI.ViewModels.Windows;
using LambdaUI.Views.Pages;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using Wpf.Ui;
namespace LambdaUI.ViewModels.Pages;

public partial class RegisterViewModel : ObservableObject
{
    private readonly IUserService _userService;
    private readonly INavigationService _navigationService;
    private readonly INotificationService _notificationService;

    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(RegisterCommand))]
    private string _username;

    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(RegisterCommand))]
    private string _password;

    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(RegisterCommand))]
    private string _confirmPassword;

    [ObservableProperty]
    private Role _selectedRole;

    [ObservableProperty]
    private string _errorMessage;

    public IRelayCommand RegisterCommand { get; }

    public RegisterViewModel(IUserService userService, INavigationService navigationService, INotificationService notificationService)
    {
        _userService = userService;
        _navigationService = navigationService;
        _notificationService = notificationService;
        RegisterCommand = new RelayCommand(Register, CanRegister);
        Roles = new ObservableCollection<Role>
        {
            Role.Student,
            Role.Teacher,
            Role.Administrator,
            Role.Director,
            Role.Parent
        };
    }

    public ObservableCollection<Role> Roles { get; set; } = [];

    private bool CanRegister()
    {
        return !string.IsNullOrEmpty(Username) 
            && !string.IsNullOrEmpty(Password) 
            && !string.IsNullOrEmpty(ConfirmPassword) 
            && Password == ConfirmPassword;
    }

    private void Register()
    {
        if (Password != ConfirmPassword)
        {
            ErrorMessage = "Пароли не совпадают";
            return;
        }

        var user = new User
        {
            Uid = Guid.NewGuid(),
            Username = Username,
            PasswordHash = Password, // todo: podv. Хэширование пароля
            Role = SelectedRole,
            Email = "",
            CreatedAt = DateTime.Now
        };

        if (_userService.Register(user))
        {
            // Сохраняем текущего пользователя
            Application.Current.Properties["CurrentUser"] = user;
            
            // Уведомляем об изменении состояния авторизации
            _notificationService.NotifyUserChanged();

            // Переходим на главную страницу
            _navigationService.Navigate(typeof(DashboardPage));
        }
        else
        {
            ErrorMessage = "Ошибка регистрации";
        }
    }
}