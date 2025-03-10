﻿namespace LambdaUI.Models;

public class Notification
{
    public Guid Uid { get; set; } // Уникальный идентификатор уведомления
    public Guid UserUid { get; set; } // Внешний ключ на User
    public string Message { get; set; }
    public DateTime CreatedAt { get; set; }

    // Navigation properties
    public User User { get; set; }
    public string Type { get; set; }
}

public enum NotificationStatus
{

}

public enum NotificationType
{
    New,
    Change,
}