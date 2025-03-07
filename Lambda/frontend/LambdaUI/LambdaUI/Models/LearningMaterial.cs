namespace LambdaUI.Models;

public class LearningMaterial
{
    public Guid Uid { get; set; } // Уникальный идентификатор учебного материала
    public Guid TeacherUid { get; set; } // Внешний ключ на Teacher
    public string Subject { get; set; }
    public string MaterialName { get; set; }
    public string MaterialData { get; set; }
    public DateTime UploadDate { get; set; }

    // Navigation properties
    public Teacher Teacher { get; set; }
}
