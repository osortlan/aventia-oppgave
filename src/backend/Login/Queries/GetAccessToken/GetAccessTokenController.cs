using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;

[ApiController]
[Route("[controller]")]
public class GetAccessTokenController(IQueryHandler<GetAccessTokenRequest, GetAccessTokenResponse> queryHandler) : ControllerBase
{
    [HttpPost("/api/auth/login")]
    public IActionResult Post(GetAccessTokenRequest request)
    {
        var response = queryHandler.Handle(request);
        if(response.accessToken != null)
            return Ok(response);
        return BadRequest(response.error);
    }
}