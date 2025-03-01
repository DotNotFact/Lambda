using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using LambdaUI.Models.Enums;
using System.Collections.ObjectModel; 

namespace LambdaUI.ViewModels.Pages;

public partial class RegisterViewModel : ObservableObject
{
    [ObservableProperty]
    private string _username;

    [ObservableProperty]
    private string _password;

    [ObservableProperty]
    private string _confirmPassword;

    public ObservableCollection<Role> Roles { get; set; }

    [ObservableProperty]
    private Role _selectedRole;

    [RelayCommand(CanExecute = nameof(CanRegister))]
    private void Register() { }

    private bool CanRegister()
    {
        return !string.IsNullOrEmpty(Username) &&
               !string.IsNullOrEmpty(Password) &&
               !string.IsNullOrEmpty(ConfirmPassword) &&
               Password == ConfirmPassword;
    }

    public RegisterViewModel()
    {
        Roles = new ObservableCollection<Role>
        {
            Role.Student,
            Role.Teacher,
            Role.DeputyDirector,
            Role.Admin,
            Role.Director,
            Role.Parent
        };
    }
}