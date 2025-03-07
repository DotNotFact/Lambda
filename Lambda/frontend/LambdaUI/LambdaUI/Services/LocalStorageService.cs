using LambdaUI.Models;
using System.Collections.ObjectModel;
using System.IO;
using System.Text.Json;
using System.Windows;

namespace LambdaUI.Services;
 
public static class LocalStorageService
{
    private const string StorageFile = "data.json";
    private static ApplicationData _data = new();

    public static void Initialize()
    {
        if (File.Exists(StorageFile))
        {
            try
            {
                var json = File.ReadAllText(StorageFile);
                _data = JsonSerializer.Deserialize<ApplicationData>(json) ?? new();
            }
            catch (Exception ex)
            {
                // Handle exception (e.g., log it)
                _data = new ApplicationData();
            }
        }
    }

    public static void SaveChanges()
    {
        try
        {
            var json = JsonSerializer.Serialize(_data, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(StorageFile, json);
        }
        catch (Exception ex)
        {
            // Handle exception (e.g., log it)
        }
    }

    public static ObservableCollection<T> GetCollection<T>() where T : class
    {
        var propertyName = $"{typeof(T).Name}s";
      
        var property = typeof(ApplicationData).GetProperty(propertyName)
            ?? throw new InvalidOperationException($"Property {propertyName} not found in ApplicationData.");
        
        if (property.GetValue(_data) is not ObservableCollection<T> collection)
        {
            collection = [];
            property.SetValue(_data, collection);
        }
        return collection;
    }

    public static void SetCollection<T>(ObservableCollection<T> collection) where T : class
    {
        var propertyName = $"{typeof(T).Name}s";

        var property = typeof(ApplicationData).GetProperty(propertyName)
            ?? throw new InvalidOperationException($"Property {propertyName} not found in ApplicationData.");
       
        property.SetValue(_data, collection);
        SaveChanges();
    } 
}


public class ApplicationData
{
    public ObservableCollection<User> Users { get; set; } = [];
    public ObservableCollection<Student> Students { get; set; } = [];
    public ObservableCollection<Teacher> Teachers { get; set; } = [];
    public ObservableCollection<Parent> Parents { get; set; } = [];
    public ObservableCollection<Group> Groups { get; set; } = [];
    public ObservableCollection<GroupStudent> GroupStudents { get; set; } = [];
    public ObservableCollection<Schedule> Schedules { get; set; } = [];
    public ObservableCollection<Attendance> Attendances { get; set; } = [];
    public ObservableCollection<Grade> Grades { get; set; } = [];
    public ObservableCollection<RetakeRequest> RetakeRequests { get; set; } = [];
    public ObservableCollection<LessonLog> LessonLogs { get; set; } = [];
    public ObservableCollection<Notification> Notifications { get; set; } = [];
    public ObservableCollection<Document> Documents { get; set; } = [];
    public ObservableCollection<FinancialData> FinancialData { get; set; } = [];
}