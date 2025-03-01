using LambdaUI.Models; 
using System.Collections.ObjectModel; 
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using LambdaUI.Models.Enums;
using LambdaUI.ViewModels.Windows;

namespace LambdaUI.ViewModels.Pages;
 
public partial class ProfileViewModel : ObservableObject
{
    // Команды
    [RelayCommand]
    private void EditProfile() { }

    [RelayCommand]
    private void ChangePassword() { }

    // Данные о текущем пользователе
    [ObservableProperty]
    private UserDto _currentUser;

    // Ключевые показатели
    [ObservableProperty]
    private int _totalGroups = 5;

    [ObservableProperty]
    private int _totalCourses = 10;

    // Последние действия
    public ObservableCollection<RecentActivity> RecentActivities { get; set; }

    public ProfileViewModel()
    {
        // Инициализация данных о текущем пользователе
        CurrentUser = StaticUserService.GetCurrentUser();

        // Инициализация последних действий
        RecentActivities = new ObservableCollection<RecentActivity>
        {
            new RecentActivity { Action = "Изменен профиль", Date = DateTime.Now, User = CurrentUser.Username },
            new RecentActivity { Action = "Записан на курс", Date = DateTime.Now, User = CurrentUser.Username },
            new RecentActivity { Action = "Участвовал в событии", Date = DateTime.Now, User = CurrentUser.Username }
        };
    }
}
