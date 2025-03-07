namespace LambdaUI.Services;

public class NotificationService : INotificationService
{
    public event Action OnUserChanged = delegate { };

    public void NotifyUserChanged()
    {
        OnUserChanged?.Invoke();
    }
}
