using LambdaUI.Models;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace LambdaUI.ViewModels.Pages;

public partial class GroupsViewModel : ObservableObject
{
    // Команды
    [RelayCommand]
    private void AddGroup() { }

    [RelayCommand]
    private void ImportGroups() { }

    [RelayCommand]
    private void EditGroup() { }

    [RelayCommand]
    private void DeleteGroup() { }

    [RelayCommand]
    private void ManageStudents() { }

    [RelayCommand]
    private void ApplyFilters() { }

    // Данные о группах
    public ObservableCollection<Group> Groups { get; set; }

    // Фильтры
    [ObservableProperty]
    private string _searchQuery;

    [ObservableProperty]
    private Teacher _selectedTeacher;

    [ObservableProperty]
    private ObservableCollection<string> _filterOptions;

    [ObservableProperty]
    private string _selectedFilterOption;

    [ObservableProperty]
    private DateTime? _selectedDate;

    // Преподаватели
    public ObservableCollection<Teacher> Teachers { get; set; }

    public GroupsViewModel()
    {
        // Инициализация данных о группах
        Groups = new ObservableCollection<Group>
        {
            new Group { Uid = Guid.NewGuid(), Name = "Группа 1", Teacher = new Teacher { FirstName = "Иван", LastName = "Иванов" } },
            new Group { Uid = Guid.NewGuid(), Name = "Группа 2", Teacher = new Teacher { FirstName = "Петр", LastName = "Петров" } },
            // Добавьте другие группы
        };

        // Инициализация преподавателей
        Teachers = new ObservableCollection<Teacher>
        {
            new Teacher { Uid = Guid.NewGuid(), FirstName = "Иван", LastName = "Иванов" },
            new Teacher { Uid = Guid.NewGuid(), FirstName = "Петр", LastName = "Петров" },
            // Добавьте другие преподаватели
        };

        // Инициализация фильтров
        FilterOptions = new ObservableCollection<string>
        {
            "Все",
            "По преподавателю",
            "По дате",
            // Другие опции фильтрации
        };
    }
}