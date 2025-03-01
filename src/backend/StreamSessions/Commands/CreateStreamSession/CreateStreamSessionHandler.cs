public class CreateStreamSessionHandler(StreamSessionContext streamSessionContext) : ICommandHandler<CreateStreamSessionRequest>
{
    public void Handle(CreateStreamSessionRequest request)
    {
        var streamSession = new StreamSession(0, request.title);
        streamSessionContext.StreamSessions.Add(streamSession);
        streamSessionContext.SaveChanges();
    }
}