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
    public ObservableCollection<GroupDto> Groups { get; set; }

    // Фильтры
    [ObservableProperty]
    private string _searchQuery;

    [ObservableProperty]
    private TeacherDto _selectedTeacher;

    [ObservableProperty]
    private ObservableCollection<string> _filterOptions;

    [ObservableProperty]
    private string _selectedFilterOption;

    [ObservableProperty]
    private DateTime? _selectedDate;

    // Преподаватели
    public ObservableCollection<TeacherDto> Teachers { get; set; }

    public GroupsViewModel()
    {
        // Инициализация данных о группах
        Groups = new ObservableCollection<GroupDto>
        {
            new GroupDto { Uid = Guid.NewGuid(), Name = "Группа 1", Teacher = new TeacherDto { FirstName = "Иван", LastName = "Иванов" } },
            new GroupDto { Uid = Guid.NewGuid(), Name = "Группа 2", Teacher = new TeacherDto { FirstName = "Петр", LastName = "Петров" } },
            // Добавьте другие группы
        };

        // Инициализация преподавателей
        Teachers = new ObservableCollection<TeacherDto>
        {
            new TeacherDto { Uid = Guid.NewGuid(), FirstName = "Иван", LastName = "Иванов" },
            new TeacherDto { Uid = Guid.NewGuid(), FirstName = "Петр", LastName = "Петров" },
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