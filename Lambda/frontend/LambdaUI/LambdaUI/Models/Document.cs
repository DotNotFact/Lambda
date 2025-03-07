namespace LambdaUI.Models;

public class Document
{
    public Guid Uid { get; set; } // Уникальный идентификатор документа
    public Guid StudentUid { get; set; } // Внешний ключ на Student
    public string DocumentType { get; set; }
    public string DocumentData { get; set; }
    public DateTime CreatedAt { get; set; }

    // Navigation properties
    public Student Student { get; set; }
}
