using System.Collections.ObjectModel;
using System.ComponentModel; 
using System.Reflection;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using LambdaUI.Models;
using LambdaUI.Models.Enums;

namespace LambdaUI.ViewModels.Pages;

public partial class AttendanceViewModel : ObservableObject
{
    // Команды
    [RelayCommand]
    private void SaveAttendance() { }

    [RelayCommand]
    private void GenerateReport() { }

    // Данные о посещаемости
    public ObservableCollection<AttendanceDto> Attendances { get; set; }

    // Фильтры
    [ObservableProperty]
    private GroupDto _selectedGroup;
    partial void OnSelectedGroupChanged(GroupDto value)
    {
        LoadAttendances();
    }

    [ObservableProperty]
    private DateTime? _selectedDate;
    partial void OnSelectedDateChanged(DateTime? value)
    {
        LoadAttendances();
    }

    // Список групп
    public ObservableCollection<GroupDto> Groups { get; set; }

    // Варианты статуса
    public ObservableCollection<string> StatusOptions { get; set; }

    public AttendanceViewModel()
    {
        // Инициализация данных о посещаемости с тестовыми данными
        Attendances = new ObservableCollection<AttendanceDto>
        {
            new AttendanceDto { Uid = Guid.NewGuid(), Student = new StudentDto { FirstName = "Иван", LastName = "Иванов" }, Schedule = new ScheduleEntty { Group = new GroupDto { Name = "Группа 1" }, StartTime = DateTime.Now }, Status = AttendanceStatus.Present },
            new AttendanceDto { Uid = Guid.NewGuid(), Student = new StudentDto { FirstName = "Петр", LastName = "Петров" }, Schedule = new ScheduleEntty { Group = new GroupDto { Name = "Группа 1" }, StartTime = DateTime.Now }, Status = AttendanceStatus.Absent },
            // Добавьте другие записи
        };

        // Инициализация списка групп
        Groups = new ObservableCollection<GroupDto>
        {
            new GroupDto { Uid = Guid.NewGuid(), Name = "Группа 1" },
            new GroupDto { Uid = Guid.NewGuid(), Name = "Группа 2" },
            // Добавьте другие группы
        };

        // Инициализация вариантов статуса
        StatusOptions = new ObservableCollection<string>
        {
            AttendanceStatus.Present.GetDescription(),
            AttendanceStatus.Absent.GetDescription(),
            AttendanceStatus.Late.GetDescription()
        };
    }

    private void LoadAttendances()
    {
        // Логика для загрузки данных о посещаемости
    }
}
public static class EnumExtensions
{
    public static string GetDescription(this Enum value)
    {
        FieldInfo fi = value.GetType().GetField(value.ToString());

        if (fi != null)
        {
            DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);

            if (attributes != null && attributes.Length > 0)
                return attributes[0].Description;
        }

        // Возвращаем имя перечисления, если описание не найдено
        return value.ToString();
    }
}