using Lambda.Modules.Users.Domain.Entities.Enums;

namespace Lambda.Modules.Users.Domain.Entities;

public class FinancialDataEntity
{
    public Guid Uid { get; set; } // Уникальный идентификатор финансовых данных
    public Guid StudentUid { get; set; } // Внешний ключ на Student
    public DateTime PaymentDate { get; set; }
    public decimal Amount { get; set; }
    public PaymentType PaymentType { get; set; }

    // Navigation properties
    public StudentEntity Student { get; set; }
}
