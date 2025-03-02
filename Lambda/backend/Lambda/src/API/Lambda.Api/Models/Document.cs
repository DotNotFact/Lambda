namespace Lambda.Api.Models;

/// <summary>
/// Документ
/// </summary>
public class Document
{
    public Guid Uid { get; set; }  

    public string DocumentType { get; set; }
    public byte[] DocumentData { get; set; }

    public DateTime CreatedAt { get; set; }
     
    //public Student Student { get; set; }
    //public Guid StudentUid { get; set; }
}
