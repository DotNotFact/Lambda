using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using LambdaUI.Models.Enums;
using LambdaUI.Views.Pages;
using Wpf.Ui.Controls;
using LambdaUI.Models;
using System.Windows;
using Wpf.Ui;
using CommunityToolkit.Mvvm.Input;

namespace LambdaUI.ViewModels.Windows;

public partial class MainWindowViewModel : ObservableObject
{
    private readonly INavigationService _navigationService;
    private readonly INotificationService _notificationService;

    public string ApplicationTitle { get; } = "LambdaUI";

    public ObservableCollection<NavigationViewItem> MenuItems { get; } = [];

    [ObservableProperty]
    private NavigationViewItem _selectedMenuItem;

    [ObservableProperty]
    private bool _isAuthenticated;

    public IRelayCommand LogoutCommand { get; }

    public MainWindowViewModel(INavigationService navigationService, INotificationService notificationService)
    {
        _navigationService = navigationService;
        _notificationService = notificationService;

        InitializeMenuItems();
        _notificationService.OnUserChanged += OnUserChanged;
        LogoutCommand = new RelayCommand(Logout);
    }

    private void InitializeMenuItems()
    { 
        MenuItems.Clear(); 

        // Получаем текущего пользователя
        if (IsAuthenticated)
        {
            // Общие пункты меню
            MenuItems.Add(new NavigationViewItem("Мониторинг", SymbolRegular.ChartMultiple24, typeof(DashboardPage)));
            MenuItems.Add(new NavigationViewItem("Расписание", SymbolRegular.Clock24, typeof(SchedulePage)));
            MenuItems.Add(new NavigationViewItem("Успеваемость", SymbolRegular.Trophy24, typeof(GradesPage)));
            MenuItems.Add(new NavigationViewItem("Посещаемость", SymbolRegular.Notebook24, typeof(AttendancePage)));
            MenuItems.Add(new NavigationViewItem("Группы", SymbolRegular.People24, typeof(GroupsPage)));
            MenuItems.Add(new NavigationViewItem("Уведомления", SymbolRegular.Megaphone24, typeof(NotificationsPage)));
            MenuItems.Add(new NavigationViewItem("Профиль", SymbolRegular.Person24, typeof(ProfilePage)));

            // Пункты меню в зависимости от роли
            if (CurrentUser.Role == Role.Administrator || CurrentUser.Role == Role.Director)
            {
                MenuItems.Add(new NavigationViewItem("Документы", SymbolRegular.Folder24, typeof(DocumentsPage))); 
                MenuItems.Add(new NavigationViewItem("Администрирование", SymbolRegular.WindowDevTools24, typeof(AdministrationPage)));
                MenuItems.Add(new NavigationViewItem("Профили", SymbolRegular.FolderPerson24, typeof(ProfilesPage)));
            }
        }
        else
        {
            MenuItems.Add(new NavigationViewItem("Авторизация", SymbolRegular.AutoFitHeight24, typeof(LoginPage)));
            MenuItems.Add(new NavigationViewItem("Регистрация", SymbolRegular.ReadAloud24, typeof(RegisterPage)));
        }

        SelectedMenuItem = MenuItems.FirstOrDefault();
    }

    private void OnUserChanged()
    {
        UpdateAuthenticationState();
        InitializeMenuItems();
    }

    private void UpdateAuthenticationState()
    {
        IsAuthenticated = Application.Current.Properties["CurrentUser"] != null;
    }

    private void Logout()
    {
        // Удаляем текущего пользователя
        Application.Current.Properties["CurrentUser"] = null;

        // Уведомляем об изменении состояния авторизации
        _notificationService.NotifyUserChanged();

        // Переходим на страницу авторизации
        _navigationService.Navigate(typeof(LoginPage));
    }

    public User CurrentUser => Application.Current.Properties["CurrentUser"] as User;
}