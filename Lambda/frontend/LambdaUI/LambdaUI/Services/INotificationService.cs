namespace LambdaUI.Services;

public interface INotificationService
{
    event Action OnUserChanged;
    void NotifyUserChanged();
}
