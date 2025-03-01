public class CreateStreamSessionHandler(StreamSessionContext streamSessionContext, INotificationService notificationService) : ICommandHandler<CreateStreamSessionRequest>
{
    public void Handle(CreateStreamSessionRequest request)
    {
        var streamSession = new StreamSession(0, request.title);
        streamSessionContext.StreamSessions.Add(streamSession);
        streamSessionContext.SaveChanges();

        notificationService.SendNotification($"new stream session created: {request.title}");
    }
}