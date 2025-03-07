using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using LambdaUI.ViewModels.Windows;
using LambdaUI.Views.Pages;
using System.Windows;
using System.Windows.Input;
using Wpf.Ui;

namespace LambdaUI.ViewModels.Pages;

public partial class LoginViewModel : ObservableObject
{
    private readonly IUserService _userService;
    private readonly INavigationService _navigationService;
    private readonly INotificationService _notificationService;

    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(LoginCommand))]
    private string _username;

    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(LoginCommand))]
    private string _password;

    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(LoginCommand))]
    private string _errorMessage;

    public IRelayCommand LoginCommand { get; }

    public LoginViewModel(IUserService userService, INavigationService navigationService, INotificationService notificationService)
    {
        _userService = userService;
        _navigationService = navigationService;
        _notificationService = notificationService;
        LoginCommand = new RelayCommand(Login, CanLogin);
    }

    private bool CanLogin()
    {
        return !string.IsNullOrEmpty(Username) && !string.IsNullOrEmpty(Password);
    }

    private void Login()
    {
        var user = _userService.Authenticate(Username, Password);
        if (user != null)
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
            ErrorMessage = "Неверные учетные данные";
        }
    }
}