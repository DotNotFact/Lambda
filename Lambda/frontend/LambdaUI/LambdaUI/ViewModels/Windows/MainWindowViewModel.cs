using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using LambdaUI.Views.Pages;
using Wpf.Ui.Controls;
using System.Windows;
using Wpf.Ui.Abstractions.Controls;
using LambdaUI.Models;
using LambdaUI.Models.Enums;

namespace LambdaUI.ViewModels.Windows;

public partial class MainWindowViewModel : ObservableObject
{
    public string ApplicationTitle { get; } = "SmartField";

    public ObservableCollection<NavigationViewItem> MenuItems { get; } = [
        new NavigationViewItem("Мониторинг", SymbolRegular.ChartMultiple24, typeof(DashboardPage)),
        new NavigationViewItem("Расписание", SymbolRegular.Clock24, typeof(SchedulePage)),
        new NavigationViewItem("Успеваемость", SymbolRegular.Trophy24, typeof(GradesPage)),
        new NavigationViewItem("Посещаемость", SymbolRegular.Notebook24, typeof(AttendancePage)),
        new NavigationViewItem("Группы", SymbolRegular.People24, typeof(GroupsPage)),
        new NavigationViewItem("Уведомления", SymbolRegular.Megaphone24, typeof(NotificationsPage)),
        new NavigationViewItem("Профиль", SymbolRegular.Person24, typeof(ProfilePage)),
        // Директор
        new NavigationViewItem("Документы", SymbolRegular.Folder24, typeof(DocumentsPage)),
        // Админ
        new NavigationViewItem("Администрирование", SymbolRegular.WindowDevTools24, typeof(AdministrationPage)),
        new NavigationViewItem("Профили", SymbolRegular.FolderPerson24, typeof(ProfilesPage)),
    ];

    public NavigationViewItem SelectedMenuItem { get; set; }

    public MainWindowViewModel()
    {
        SelectedMenuItem = MenuItems.First();
    }
}

public abstract class ViewModel : ObservableObject, INavigationAware
{
    /// <inheritdoc />
    public virtual async Task OnNavigatedToAsync()
    {
        using CancellationTokenSource cts = new();

        await DispatchAsync(OnNavigatedTo, cts.Token);
    }

    /// <summary>
    /// Handles the event that is fired after the component is navigated to.
    /// </summary>
    // ReSharper disable once MemberCanBeProtected.Global
    public virtual void OnNavigatedTo() { }

    /// <inheritdoc />
    public virtual async Task OnNavigatedFromAsync()
    {
        using CancellationTokenSource cts = new();

        await DispatchAsync(OnNavigatedFrom, cts.Token);
    }

    /// <summary>
    /// Handles the event that is fired before the component is navigated from.
    /// </summary>
    // ReSharper disable once MemberCanBeProtected.Global
    public virtual void OnNavigatedFrom() { }

    /// <summary>
    /// Dispatches the specified action on the UI thread.
    /// </summary>
    /// <param name="action">The action to be dispatched.</param>
    /// <param name="cancellationToken">A cancellation token that can be used to cancel the operation.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    protected static async Task DispatchAsync(Action action, CancellationToken cancellationToken)
    {
        if (cancellationToken.IsCancellationRequested)
        {
            return;
        }

        await Application.Current.Dispatcher.InvokeAsync(action);
    }
}

public static class StaticUserService
{
    private static ObservableCollection<UserDto> _users;

    static StaticUserService()
    {
        // Хардкодированные данные
        _users = new ObservableCollection<UserDto>
            {
                new UserDto
                {
                    Uid = Guid.NewGuid(),
                    Username = "admin",
                    PasswordHash = "admin123",
                    Email = "admin@example.com",
                    Role = Role.Admin,
                    CreatedAt = DateTime.Now
                },
                new UserDto
                {
                    Uid = Guid.NewGuid(),
                    Username = "teacher",
                    PasswordHash = "teacher123",
                    Email = "teacher@example.com",
                    Role = Role.Teacher,
                    CreatedAt = DateTime.Now
                },
                new UserDto
                {
                    Uid = Guid.NewGuid(),
                    Username = "student",
                    PasswordHash = "student123",
                    Email = "student@example.com",
                    Role = Role.Student,
                    CreatedAt = DateTime.Now
                }
            };
    }

    public static UserDto GetCurrentUser()
    {
        // Логика для получения текущего пользователя
        return _users[0]; // Для тестирования возвращаем первого пользователя
    }

    public static ObservableCollection<UserDto> GetAllUsers()
    {
        return _users;
    }

    public static void AddUser(UserDto user)
    {
        _users.Add(user);
    }

    public static void DeleteUser(Guid userId)
    {
        var user = _users.FirstOrDefault(u => u.Uid == userId);
        if (user != null)
        {
            _users.Remove(user);
        }
    }
}
