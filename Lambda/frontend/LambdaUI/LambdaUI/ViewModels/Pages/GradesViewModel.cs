using LambdaUI.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;

namespace LambdaUI.ViewModels.Pages;
 
public partial class GradesViewModel : ObservableObject
{
    // Команды
    [RelayCommand]
    private void AddGrade() { }

    [RelayCommand]
    private void ImportGrades() { }

    [RelayCommand]
    private void EditGrade() { }

    [RelayCommand]
    private void DeleteGrade() { }

    // Данные об оценках
    public ObservableCollection<Grade> Grades { get; set; }

    // Фильтры
    //[ObservableProperty]
    //private Group _selectedGroup;
    //partial void OnSelectedGroupChanged(Group value)
    //{
    //    LoadGrades();
    //}

    [ObservableProperty]
    private string _selectedSubject;
    partial void OnSelectedSubjectChanged(string value)
    {
        LoadGrades();
    }

    //[ObservableProperty]
    //private DateTime? _selectedDate;
    //partial void OnSelectedDateChanged(DateTime? value)
    //{
    //    LoadGrades();
    //}

    // Список групп и предметов
    public ObservableCollection<Group> Groups { get; set; }
    public ObservableCollection<string> Subjects { get; set; }

    public GradesViewModel()
    { 
        Subjects = new ObservableCollection<string>
        {
            "Математика",
            "Физика",
            "Химия",
            "История",
            // Добавьте другие предметы
        };

        // Инициализация данных об оценках с тестовыми данными
        Grades = new ObservableCollection<Grade>
        {
            new Grade { Uid = Guid.NewGuid(), Student = new Student { FirstName = "Иван", LastName = "Иванов" }, Schedule = new Schedule { Group = new Group { Name = "Группа 1" }, Subject = "Математика" }, GradeValue = 85, GradeDate = DateTime.Now },
            new Grade { Uid = Guid.NewGuid(), Student = new Student { FirstName = "Петр", LastName = "Петров" }, Schedule = new Schedule { Group = new Group { Name = "Группа 1" }, Subject = "Физика" }, GradeValue = 90, GradeDate = DateTime.Now },
            // Добавьте другие записи
        };


        // Инициализация команд
        AddRandomLessonCommand = new RelayCommand(AddRandomLesson);
        DeleteLessonCommand = new RelayCommand<Guid>(DeleteLesson);
        EditLessonCommand = new RelayCommand<Guid>(EditLesson);

        // Инициализация данных о расписании с тестовыми данными
        Lessons = new ObservableCollection<Schedule>
        {
            new()
            {
                Uid = Guid.NewGuid(),
                Group = new Group { Name = "Группа 1" }, 
                Teacher = new Teacher 
                { 
                    FirstName = "Иван",
                    LastName = "Иванов" 
                }, 
                Subject = "Математика",
                Classroom = "101",
                StartTime = DateTime.Now,
                EndTime = DateTime.Now.AddHours(1) 
            },
            new Schedule { Uid = Guid.NewGuid(), Group = new Group { Name = "Группа 2" }, Teacher = new Teacher { FirstName = "Петр", LastName = "Петров" }, Subject = "Физика", Classroom = "102", StartTime = DateTime.Now, EndTime = DateTime.Now.AddHours(1) },
            new Schedule { Uid = Guid.NewGuid(), Group = new Group { Name = "Группа 3" }, Teacher = new Teacher { FirstName = "Алексей", LastName = "Смирнов" }, Subject = "Химия", Classroom = "103", StartTime = DateTime.Now, EndTime = DateTime.Now.AddHours(1) },
            // Добавьте другие занятия
        };

        // Инициализация списка групп
        Groups = new ObservableCollection<Group>
        {
            new Group { Uid = Guid.NewGuid(), Name = "Группа 1" },
            new Group { Uid = Guid.NewGuid(), Name = "Группа 2" },
            new Group { Uid = Guid.NewGuid(), Name = "Группа 3" },
            // Добавьте другие группы
        };

        // Инициализация списка преподавателей
        Teachers = new ObservableCollection<Teacher>
        {
            new Teacher { Uid = Guid.NewGuid(), FirstName = "Иван", LastName = "Иванов" },
            new Teacher { Uid = Guid.NewGuid(), FirstName = "Петр", LastName = "Петров" },
            new Teacher { Uid = Guid.NewGuid(), FirstName = "Алексей", LastName = "Смирнов" },
            // Добавьте другие преподаватели
        };
    }

    private void LoadGrades()
    {
        // Логика для загрузки данных об оценках
    }

    // todo: удалить/изменить, сделал copy -> paste

    // Команды
    public ICommand AddRandomLessonCommand { get; }
    public ICommand DeleteLessonCommand { get; }
    public ICommand EditLessonCommand { get; }

    // Данные о расписании
    public ObservableCollection<Schedule> Lessons { get; set; }

    // Фильтры
    private Group _selectedGroup;
    public Group SelectedGroup
    {
        get => _selectedGroup;
        set
        {
            SetProperty(ref _selectedGroup, value);
            ApplyFilters();
        }
    }

    private Teacher _selectedTeacher;
    public Teacher SelectedTeacher
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

    private Schedule _selectedLesson;
    public Schedule SelectedLesson
    {
        get => _selectedLesson;
        set => SetProperty(ref _selectedLesson, value);
    }

    // Список групп и преподавателей
    public ObservableCollection<Teacher> Teachers { get; set; }
     
    private void AddRandomLesson()
    {
        // Логика для добавления случайного занятия
        var random = new Random();
        var newLesson = new Schedule
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
            filteredLessons = new ObservableCollection<Schedule>(filteredLessons.Where(l => l.Group.Name == SelectedGroup.Name));
        }

        if (SelectedTeacher != null)
        {
            filteredLessons = new ObservableCollection<Schedule>(filteredLessons.Where(l => l.Teacher.FirstName == SelectedTeacher.FirstName && l.Teacher.LastName == SelectedTeacher.LastName));
        }

        if (SelectedDate.HasValue)
        {
            filteredLessons = new ObservableCollection<Schedule>(filteredLessons.Where(l => l.StartTime.Date == SelectedDate.Value.Date));
        }

        Lessons = filteredLessons;
        OnPropertyChanged(nameof(Lessons));
    }
}