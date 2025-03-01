using Microsoft.AspNetCore.SignalR;

public interface INotificationService
{
    Task SendNotification(string notificationType, string message, object data);
}

public class NotificationService : INotificationService
{
    private readonly IHubContext<NotificationHub> _hubContext;

    public NotificationService(IHubContext<NotificationHub> hubContext)
    {
        _hubContext = hubContext;
    }

    public async Task SendNotification(string notificationType, string message, object data)
    {
        await _hubContext.Clients.All.SendAsync("ReceiveMessage", notificationType, message, data);
    }
}