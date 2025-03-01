using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using LiveCharts;
using LiveCharts.Wpf; 
using System.Collections.ObjectModel;
using System.Windows.Media;

namespace LambdaUI.ViewModels.Pages;

public partial class DashboardViewModel : ObservableObject
{ 
    [RelayCommand]
    private void AddStudent()
    {
        // Логика для добавления студента
    }

    [RelayCommand]
    private void ManageGroups()
    {
        // Логика для управления группами
    }

    [RelayCommand]
    private void ManageSchedule()
    {
        // Логика для управления расписанием
    }

    // Данные для ключевых показателей
    [ObservableProperty]
    private int _totalStudents = 150;

    [ObservableProperty]
    private int _totalGroups = 10;

    [ObservableProperty]
    private int _upcomingEvents = 5;

    // Данные для диаграмм
    public SeriesCollection AttendanceChart { get; set; }
    public SeriesCollection GradesChart { get; set; }

    // Последние действия
    public ObservableCollection<RecentActivity> RecentActivities { get; set; }

    public DashboardViewModel()
    { 
        // Инициализация диаграмм
        AttendanceChart = [
            new PieSeries
            {
                Title = "Присутствие",
                Values = new ChartValues<double> { 120 },
                Fill = Brushes.Green
            },
            new PieSeries
            {
                Title = "Отсутствие",
                Values = new ChartValues<double> { 30 },
                Fill = Brushes.Red
            }
        ];

        GradesChart = [
            new PieSeries
            {
                Title = "Оценка 1 -",
                Values = new ChartValues<double> { 2 },
                Fill = Brushes.DarkRed
            },
            new PieSeries
            {
                Title = "Оценка 2 -",
                Values = new ChartValues<double> { 12 },
                Fill = Brushes.Red
            },
            new PieSeries
            {
                Title = "Оценка 3 -",
                Values = new ChartValues<double> { 20 },
                Fill = Brushes.Yellow
            },
            new PieSeries
            {
                Title = "Оценка 4 -",
                Values = new ChartValues<double> { 48 },
                Fill = Brushes.LightGreen
            },
            new PieSeries
            {
                Title = "Оценка 5 -",
                Values = new ChartValues<double> { 32 },
                Fill = Brushes.Green
            }
        ];

        // Инициализация последних действий
        RecentActivities = [
            new() { Action = "Добавлен новый студент", Date = DateTime.Now, User = "admin" },
            new() { Action = "Создана новая группа", Date = DateTime.Now, User = "teacher" },
            new() { Action = "Запланировано новое событие", Date = DateTime.Now, User = "admin" },
            new() { Action = "Обновлено расписание", Date = DateTime.Now, User = "admin" },
            new() { Action = "Добавлен новый преподаватель", Date = DateTime.Now, User = "admin" },
            new() { Action = "Обновлены оценки студентов", Date = DateTime.Now, User = "teacher" },
            new() { Action = "Добавлен новый курс", Date = DateTime.Now, User = "admin" },
            new() { Action = "Обновлена информация о студенте", Date = DateTime.Now, User = "teacher" },
        ];
    }
}

// Класс для представления последних действий
public class RecentActivity
{
    public string Action { get; set; }
    public DateTime Date { get; set; }
    public string User { get; set; }
}