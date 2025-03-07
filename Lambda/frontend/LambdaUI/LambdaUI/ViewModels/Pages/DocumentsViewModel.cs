using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.Input;
using LambdaUI.Models;

namespace LambdaUI.ViewModels.Pages;
 
public partial class DocumentsViewModel : ObservableObject
{
    // Команды
    [RelayCommand]
    private void UploadDocument() { }

    [RelayCommand]
    private void EditDocument() { }

    [RelayCommand]
    private void DeleteDocument() { }

    [RelayCommand]
    private void PreviousPage() { }

    [RelayCommand]
    private void NextPage() { }

    // Данные для таблицы документов
    public ObservableCollection<Document> Documents { get; set; }

    // Параметры поиска и фильтрации
    [ObservableProperty]
    private string _searchQuery;

    public ObservableCollection<string> DocumentTypes { get; set; }

    [ObservableProperty]
    private string _selectedDocumentType;

    [ObservableProperty]
    private int _currentPage = 1;

    public DocumentsViewModel()
    {
        // Инициализация данных для таблицы
        Documents = [
            new Document { Uid = Guid.NewGuid(), DocumentType = "Зачетная книжка", Student = new Student { FirstName = "Иван", LastName = "Иванов" }, CreatedAt = DateTime.Now, DocumentData = "Данные документа" },
            new Document { Uid = Guid.NewGuid(), DocumentType = "Диплом", Student = new Student { FirstName = "Петр", LastName = "Петров" }, CreatedAt = DateTime.Now, DocumentData = "Данные документа" },
            // Добавьте больше документов для примера
        ];

        // Инициализация данных для фильтрации
        DocumentTypes = [
            "Зачетная книжка",
            "Диплом",
            "Справка",
        ];
    }
}