public class GetStreamSessionsHandler : IRequestHandler<GetStreamSessionsResponse>
{
    public GetStreamSessionsResponse Handle()
    {
        var streamSessions = new [] {
            new StreamSession ("kjeks"),
            new StreamSession ("Kake"),
            new StreamSession ("Bjørn"),
        };
        return new GetStreamSessionsResponse(streamSessions.ToList());
    }
}