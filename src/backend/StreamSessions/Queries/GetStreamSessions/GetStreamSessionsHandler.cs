using System.Linq;
public class GetStreamSessionsHandler(StreamSessionContext streamSessionContext) : IQueryHandler<GetStreamSessionsResponse>
{
    public GetStreamSessionsResponse Handle() =>
        new GetStreamSessionsResponse(
            streamSessionContext.StreamSessions
                .Select(ss => new StreamSession(ss.Id,ss.Title))
                .ToList());
}