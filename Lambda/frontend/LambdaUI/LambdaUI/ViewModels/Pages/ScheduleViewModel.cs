﻿using LambdaUI.Models; 
using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel; 
using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;

namespace LambdaUI.ViewModels.Pages;

public class ScheduleViewModel : ObservableObject
{
    // Команды
    public ICommand AddRandomLessonCommand { get; }
    public ICommand DeleteLessonCommand { get; }
    public ICommand EditLessonCommand { get; }

    // Данные о расписании
    public ObservableCollection<ScheduleEntty> Lessons { get; set; }

    // Фильтры
    private GroupDto _selectedGroup;
    public GroupDto SelectedGroup
    {
        get => _selectedGroup;
        set
        {
            SetProperty(ref _selectedGroup, value);
            ApplyFilters();
        }
    }

    private TeacherDto _selectedTeacher;
    public TeacherDto SelectedTeacher
    {
        get => _selectedTeacher;
        set
        {
            SetProperty(ref _selectedTeacher, value);
            ApplyFilters();
        }
    }

    private DateTime? _selectedDate;
    public DateTime? SelectedDate
    {
        get => _selectedDate;
        set
        {
            SetProperty(ref _selectedDate, value);
            ApplyFilters();
        }
    }

    private ScheduleEntty _selectedLesson;
    public ScheduleEntty SelectedLesson
    {
        get => _selectedLesson;
        set => SetProperty(ref _selectedLesson, value);
    }

    // Список групп и преподавателей
    public ObservableCollection<GroupDto> Groups { get; set; }
    public ObservableCollection<TeacherDto> Teachers { get; set; }

    public ScheduleViewModel()
    {
        // Инициализация команд
        AddRandomLessonCommand = new RelayCommand(AddRandomLesson);
        DeleteLessonCommand = new RelayCommand<Guid>(DeleteLesson);
        EditLessonCommand = new RelayCommand<Guid>(EditLesson);

        // Инициализация данных о расписании с тестовыми данными
        Lessons = new ObservableCollection<ScheduleEntty>
        {
            new ScheduleEntty { Uid = Guid.NewGuid(), Group = new GroupDto { Name = "Группа 1" }, Teacher = new TeacherDto { FirstName = "Иван", LastName = "Иванов" }, Subject = "Математика", Classroom = "101", StartTime = DateTime.Now, EndTime = DateTime.Now.AddHours(1) },
            new ScheduleEntty { Uid = Guid.NewGuid(), Group = new GroupDto { Name = "Группа 2" }, Teacher = new TeacherDto { FirstName = "Петр", LastName = "Петров" }, Subject = "Физика", Classroom = "102", StartTime = DateTime.Now, EndTime = DateTime.Now.AddHours(1) },
            new ScheduleEntty { Uid = Guid.NewGuid(), Group = new GroupDto { Name = "Группа 3" }, Teacher = new TeacherDto { FirstName = "Алексей", LastName = "Смирнов" }, Subject = "Химия", Classroom = "103", StartTime = DateTime.Now, EndTime = DateTime.Now.AddHours(1) },
            // Добавьте другие занятия
        };

        // Инициализация списка групп
        Groups = new ObservableCollection<GroupDto>
        {
            new GroupDto { Uid = Guid.NewGuid(), Name = "Группа 1" },
            new GroupDto { Uid = Guid.NewGuid(), Name = "Группа 2" },
            new GroupDto { Uid = Guid.NewGuid(), Name = "Группа 3" },
            // Добавьте другие группы
        };

        // Инициализация списка преподавателей
        Teachers = new ObservableCollection<TeacherDto>
        {
            new TeacherDto { Uid = Guid.NewGuid(), FirstName = "Иван", LastName = "Иванов" },
            new TeacherDto { Uid = Guid.NewGuid(), FirstName = "Петр", LastName = "Петров" },
            new TeacherDto { Uid = Guid.NewGuid(), FirstName = "Алексей", LastName = "Смирнов" },
            // Добавьте другие преподаватели
        };
    }

    private void AddRandomLesson()
    {
        // Логика для добавления случайного занятия
        var random = new Random();
        var newLesson = new ScheduleEntty
        {
            Uid = Guid.NewGuid(),
            Group = Groups[random.Next(Groups.Count)],
            Teacher = Teachers[random.Next(Teachers.Count)],
            Subject = "Предмет " + (Lessons.Count + 1),
            Classroom = "Аудитория " + (random.Next(1, 10) * 10 + random.Next(1, 10)),
            StartTime = DateTime.Now.AddHours(random.Next(1, 10)),
            EndTime = DateTime.Now.AddHours(random.Next(11, 20))
        };
        Lessons.Add(newLesson);
    }

    private void DeleteLesson(Guid lessonId)
    {
        // Логика для удаления занятия
        var lesson = Lessons.FirstOrDefault(l => l.Uid == lessonId);
        if (lesson != null)
        {
            Lessons.Remove(lesson);
        }
    }

    private void EditLesson(Guid lessonId)
    {
        // Логика для редактирования занятия
        var lesson = Lessons.FirstOrDefault(l => l.Uid == lessonId);
        if (lesson != null)
        {
            // Открыть окно редактирования или выполнить другую логику
        }
    }

    private void ApplyFilters()
    {
        // Логика для применения фильтров
        var filteredLessons = Lessons;

        if (SelectedGroup != null)
        {
            filteredLessons = new ObservableCollection<ScheduleEntty>(filteredLessons.Where(l => l.Group.Name == SelectedGroup.Name));
        }

        if (SelectedTeacher != null)
        {
            filteredLessons = new ObservableCollection<ScheduleEntty>(filteredLessons.Where(l => l.Teacher.FirstName == SelectedTeacher.FirstName && l.Teacher.LastName == SelectedTeacher.LastName));
        }

        if (SelectedDate.HasValue)
        {
            filteredLessons = new ObservableCollection<ScheduleEntty>(filteredLessons.Where(l => l.StartTime.Date == SelectedDate.Value.Date));
        }

        Lessons = filteredLessons;
        OnPropertyChanged(nameof(Lessons));
    }
}