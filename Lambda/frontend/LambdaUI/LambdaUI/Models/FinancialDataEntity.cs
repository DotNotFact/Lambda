using LambdaUI.Models.Enums;

namespace LambdaUI.Models;

public class FinancialDataDto
{
    public Guid Uid { get; set; } // Уникальный идентификатор финансовых данных
    public Guid StudentUid { get; set; } // Внешний ключ на Student
    public DateTime PaymentDate { get; set; }
    public decimal Amount { get; set; }
    public PaymentType PaymentType { get; set; }

    // Navigation properties
    public StudentDto Student { get; set; }
}
