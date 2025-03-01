using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input; 

namespace LambdaUI.ViewModels.Pages;

public partial class LoginViewModel : ObservableObject
{
    [ObservableProperty]
    private string _username;

    [ObservableProperty]
    private string _password;

    [RelayCommand(CanExecute = nameof(CanLogin))]
    private void Login() { }

    private bool CanLogin()
    {
        return !string.IsNullOrEmpty(Username) && !string.IsNullOrEmpty(Password);
    }
}