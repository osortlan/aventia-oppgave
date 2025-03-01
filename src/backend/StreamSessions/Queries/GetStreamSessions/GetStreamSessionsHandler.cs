public class GetStreamSessionsHandler(StreamSessionContext streamSessionContext) : IQueryHandler<GetStreamSessionsResponse>
{
    public GetStreamSessionsResponse Handle() =>
        new GetStreamSessionsResponse(streamSessionContext.StreamSessions.ToList());
}