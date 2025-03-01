public class GetStreamSessionsHandler(StreamSessionContext streamSessionContext) : IRequestHandler<GetStreamSessionsResponse>
{   

    public GetStreamSessionsResponse Handle() =>
        new GetStreamSessionsResponse(streamSessionContext.StreamSessions.ToList());
        
    
}