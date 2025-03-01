using Microsoft.AspNetCore.SignalR;

public interface INotificationService
{
    Task SendNotification(string message);
}

public class NotificationService : INotificationService
{
    private readonly IHubContext<NotificationHub> _hubContext;

    public NotificationService(IHubContext<NotificationHub> hubContext)
    {
        _hubContext = hubContext;
    }

    public async Task SendNotification(string message)
    {
        await _hubContext.Clients.All.SendAsync("ReceiveMessage", message);
    }
}