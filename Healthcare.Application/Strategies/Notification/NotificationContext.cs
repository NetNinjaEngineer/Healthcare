namespace Healthcare.Application.Strategies.Notification;
public sealed class NotificationContext
{
    private INotificationStrategy _notificationStrategy;

    public NotificationContext(INotificationStrategy notificationStrategy)
    {
        _notificationStrategy = notificationStrategy;
    }

    public void SetNotificationStrategy(INotificationStrategy notificationStrategy)
        => _notificationStrategy = notificationStrategy;

    public void SendNotification(string message, string userId)
        => _notificationStrategy.SendNotification(message, userId);

}
