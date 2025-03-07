using LambdaUI.Models; 
using System.Collections.ObjectModel; 
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using LambdaUI.Models.Enums;
using LambdaUI.ViewModels.Windows;
using System.Windows;

namespace LambdaUI.ViewModels.Pages;
 
public partial class ProfileViewModel : ObservableObject
{ 
    [RelayCommand]
    private void EditProfile() { }

    [RelayCommand]
    private void ChangePassword() { }
     
    public User CurrentUser => Application.Current.Properties["CurrentUser"] as User;
     
    [ObservableProperty]
    private int _totalGroups = 5;

    [ObservableProperty]
    private int _totalCourses = 10;
     
    public ObservableCollection<RecentActivity> RecentActivities { get; set; }

    public ProfileViewModel()
    {  
        RecentActivities =        [
            new() { Action = "Изменен профиль", Date = DateTime.Now, User = CurrentUser.Username },
            new() { Action = "Записан на курс", Date = DateTime.Now, User = CurrentUser.Username },
            new() { Action = "Участвовал в событии", Date = DateTime.Now, User = CurrentUser.Username }
        ];
    }
}
