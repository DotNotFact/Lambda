using LambdaUI.Models;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;
using System.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.ComponentModel;
namespace LambdaUI.ViewModels.Pages;

public partial class NotificationsViewModel : ObservableObject
{
    // Команды
    [RelayCommand]
    private void SendNotification() { }

    [RelayCommand]
    private void EditNotification() { }

    [RelayCommand]
    private void DeleteNotification() { }

    [RelayCommand]
    private void PreviousPage() { }

    [RelayCommand]
    private void NextPage() { }

    // Данные для списка уведомлений
    public ObservableCollection<NotificationDto> Notifications { get; set; }

    // Параметры фильтрации
    [ObservableProperty]
    private string _searchQuery;

    public ObservableCollection<string> NotificationTypes { get; set; }

    [ObservableProperty]
    private string _selectedType;

    [ObservableProperty]
    private DateTime? _selectedDate;

    [ObservableProperty]
    private int _currentPage = 1;

    public NotificationsViewModel()
    {
        // Инициализация данных для списка
        Notifications = new ObservableCollection<NotificationDto>
        {
            new NotificationDto { Uid = Guid.NewGuid(), Message = "Изменено расписание", CreatedAt = DateTime.Now, Type = "Изменение" },
            new NotificationDto { Uid = Guid.NewGuid(), Message = "Новое уведомление", CreatedAt = DateTime.Now, Type = "Новое" },
            // Добавьте больше уведомлений для примера
        };

        // Инициализация данных для фильтрации
        NotificationTypes = new ObservableCollection<string>
        {
            "Изменение",
            "Новое",
            "Важно"
        };
    }
}