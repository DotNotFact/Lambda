using LambdaUI.Models; 
using System.Collections.ObjectModel; 

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace LambdaUI.ViewModels.Pages;

public partial class ProfilesViewModel : ObservableObject
{
    // Команды
    [RelayCommand]
    private void AddStudent() { }

    [RelayCommand]
    private void ImportStudents() { }

    [RelayCommand]
    private void Refresh() { }

    [RelayCommand]
    private void EditStudent() { }

    [RelayCommand]
    private void DeleteStudent() { }

    [RelayCommand]
    private void PreviousPage() { }

    [RelayCommand]
    private void NextPage() { }

    // Данные для таблицы студентов
    public ObservableCollection<StudentDto> Students { get; set; } = [];
    public ObservableCollection<StudentDto> RecentActivities { get; set; } = [];
    
    public int TotalGroups { get; set; } = 10;

    // Параметры поиска и пагинации
    [ObservableProperty]
    private string _searchQuery;

    [ObservableProperty]
    private int _currentPage = 1;

    public ProfilesViewModel()
    {
        // Инициализация данных для таблицы
        Students = new ObservableCollection<StudentDto>
        {
            new StudentDto { Uid = Guid.NewGuid(), FirstName = "Иван", LastName = "Иванов", BirthDate = DateTime.Now.AddYears(-20), ContactInfo = "ivanov@example.com", Address = "Москва" },
            new StudentDto { Uid = Guid.NewGuid(), FirstName = "Петр", LastName = "Петров", BirthDate = DateTime.Now.AddYears(-22), ContactInfo = "petrov@example.com", Address = "Санкт-Петербург" },
            // Добавьте больше студентов для примера
        };
    }
}