namespace Lambda.Api.Models;

/// <summary>
/// Финансовые данные
/// </summary>
public class FinancialData
{
    public Guid Uid { get; set; }  
    
    public DateTime PaymentDate { get; set; }
    public decimal Amount { get; set; }

    public PaymentType PaymentType { get; set; }
     
    //public Student Student { get; set; }
    //public Guid StudentUid { get; set; }
}

public enum PaymentType
{
    Tuition, 
}
