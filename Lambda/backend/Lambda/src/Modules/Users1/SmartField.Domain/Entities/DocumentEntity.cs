namespace Lambda.Modules.Users.Domain.Entities;

public class DocumentEntity
{
    public Guid Uid { get; set; } // Уникальный идентификатор документа
    public Guid StudentUid { get; set; } // Внешний ключ на Student
    public string DocumentType { get; set; }
    public string DocumentData { get; set; }
    public DateTime CreatedAt { get; set; }

    // Navigation properties
    public StudentEntity Student { get; set; }
}
