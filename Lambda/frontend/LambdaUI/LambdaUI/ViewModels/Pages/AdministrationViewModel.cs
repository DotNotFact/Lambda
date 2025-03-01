using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using LambdaUI.Models;
using LambdaUI.Models.Enums;
using LambdaUI.ViewModels.Windows;
using System.Collections.ObjectModel; 
using System.Windows.Input;

namespace LambdaUI.ViewModels.Pages;

public class AdministrationViewModel : ObservableObject
{
    // Команды
    public ICommand AddUserCommand { get; }
    public ICommand EditUserCommand { get; }
    public ICommand DeleteUserCommand { get; }
    public ICommand AddAccessRightCommand { get; }
    public ICommand EditAccessRightCommand { get; }
    public ICommand DeleteAccessRightCommand { get; }
    public ICommand StartBackupCommand { get; }
    public ICommand RestoreBackupCommand { get; }

    // Данные для таблицы пользователей
    public ObservableCollection<UserDto> Users { get; set; }

    // Параметры поиска
    private string _searchQuery;
    public string SearchQuery
    {
        get => _searchQuery;
        set
        {
            SetProperty(ref _searchQuery, value);
            // TODO: Реализовать фильтрацию пользователей
        }
    }

    // Добавьте свойства для фильтрации
    private DateTime? _selectedDate;
    public DateTime? SelectedDate
    {
        get => _selectedDate;
        set => SetProperty(ref _selectedDate, value);
    }

    private UserDto _selectedUser;
    public UserDto SelectedUser
    {
        get => _selectedUser;
        set => SetProperty(ref _selectedUser, value);
    }

    // Обновите методы для применения фильтров
    private void ApplyFilters()
    {
        // Логика применения фильтров
    }

    // Данные для ролей (для выпадающего списка)
    public ObservableCollection<Role> Roles { get; set; }

    // Данные для таблицы прав доступа
    public ObservableCollection<AccessRightDto> AccessRights { get; set; }

    // Данные для информации о последнем резервном копировании
    private string _lastBackupInfo;
    public string LastBackupInfo
    {
        get => _lastBackupInfo;
        set => SetProperty(ref _lastBackupInfo, value);
    }

    public AdministrationViewModel()
    {
        // Инициализация команд
        AddUserCommand = new RelayCommand(AddUser);
        EditUserCommand = new RelayCommand(EditUser);
        DeleteUserCommand = new RelayCommand(DeleteUser);
        AddAccessRightCommand = new RelayCommand(AddAccessRight);
        EditAccessRightCommand = new RelayCommand(EditAccessRight);
        DeleteAccessRightCommand = new RelayCommand(DeleteAccessRight);
        StartBackupCommand = new RelayCommand(StartBackup);
        RestoreBackupCommand = new RelayCommand(RestoreBackup);

        // Инициализация данных для ролей
        Roles = new ObservableCollection<Role>
        {
            Role.Student,
            Role.Teacher,
            Role.DeputyDirector,
            Role.Admin,
            Role.Director,
            Role.Parent,
        };

        // Инициализация данных для информации о последнем резервном копировании
        LastBackupInfo = "Последнее резервное копирование: 2025-01-18 15:30";

        // Получение данных от сервисов
        Users = StaticUserService.GetAllUsers(); // userService.GetAllUsers();
        AccessRights = StaticAdministrationService.GetAccessRights();
    }

    private void AddUser()
    {
        // Логика для добавления пользователя
    }

    private void EditUser()
    {
        // Логика для редактирования пользователя
    }

    private void DeleteUser()
    {
        // Логика для удаления пользователя
    }

    private void AddAccessRight()
    {
        // Логика для добавления права доступа
    }

    private void EditAccessRight()
    {
        // Логика для редактирования права доступа
    }

    private void DeleteAccessRight()
    {
        // Логика для удаления права доступа
    }

    private void StartBackup()
    {
        // Логика для запуска резервного копирования
    }

    private void RestoreBackup()
    {
        // Логика для восстановления данных
    }
}

// todo: вынести в БД и привязать
public class ActionDto
{
    public Guid Uid { get; set; } // Уникальный идентификатор действия
    public UserDto User { get; set; } // Пользователь, совершивший действие
    public string Action { get; set; } // Описание действия
    public DateTime ActionDate { get; set; } // Дата и время действия
}

public class AccessRightDto
{
    public Guid Uid { get; set; } // Уникальный идентификатор права доступа
    public Role Role { get; set; } // Роль, к которой относится право доступа
    public string Right { get; set; } // Описание права доступа
}




//

public static class StaticAdministrationService
{
    private static ObservableCollection<AccessRightDto> _accessRights;

    static StaticAdministrationService()
    {
        // Хардкодированные данные
        _accessRights = new ObservableCollection<AccessRightDto>
            {
                new AccessRightDto
                {
                    Uid = Guid.NewGuid(),
                    Role = Role.Admin,
                    Right = "Полный доступ"
                },
                new AccessRightDto
                {
                    Uid = Guid.NewGuid(),
                    Role = Role.Teacher,
                    Right = "Доступ к расписанию"
                }
            };
    }

    public static ObservableCollection<AccessRightDto> GetAccessRights()
    {
        return _accessRights;
    }

    public static void AddAccessRight(AccessRightDto accessRight)
    {
        _accessRights.Add(accessRight);
    }

    public static void DeleteAccessRight(Guid accessRightId)
    {
        var accessRight = _accessRights.FirstOrDefault(ar => ar.Uid == accessRightId);
        if (accessRight != null)
        {
            _accessRights.Remove(accessRight);
        }
    }
}