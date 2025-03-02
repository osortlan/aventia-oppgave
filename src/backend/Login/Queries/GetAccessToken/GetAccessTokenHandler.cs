public class GetAccessTokenHandler(IAuthService authService) : IQueryHandler<GetAccessTokenRequest, GetAccessTokenResponse>
{
    public GetAccessTokenResponse Handle(GetAccessTokenRequest request)
    {
        if(authService.Authenticate(request.username, request.password))
            return new GetAccessTokenResponse(authService.GenerateToken(request.username), null);
        return new GetAccessTokenResponse(null, "Wrong username or password");
        //    return Ok(new GetTokenResponse(GenerateToken(request.username,request.username)));
        //return BadRequest("Wrong username or password");
    }
}