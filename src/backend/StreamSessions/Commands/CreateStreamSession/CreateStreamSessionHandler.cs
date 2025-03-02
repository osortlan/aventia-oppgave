public class CreateStreamSessionHandler(StreamSessionContext streamSessionContext, INotificationService notificationService) : ICommandHandler<CreateStreamSessionRequest>
{
    public void Handle(CreateStreamSessionRequest request)
    {
        var streamSession = new StreamSessionDao
        {
            Title = request.title
        };
        streamSessionContext.StreamSessions.Add(streamSession);
        streamSessionContext.SaveChanges();

        notificationService.SendNotification("session-created", $"new stream session created: {request.title}", streamSession);
    }
}