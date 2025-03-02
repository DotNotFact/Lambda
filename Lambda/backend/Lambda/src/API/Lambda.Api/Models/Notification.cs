namespace Lambda.Api.Models;

/// <summary>
/// Уведомление
/// </summary>
public class Notification
{
    public Guid Uid { get; set; } 
    public Guid UserUid { get; set; }  
    public string Message { get; set; }
    public DateTime CreatedAt { get; set; }
     
    //public User User { get; set; }
    //public string Type { get; set; }
}

public enum NotificationStatus
{

}

public enum NotificationType
{
    New,
    Change,
}
