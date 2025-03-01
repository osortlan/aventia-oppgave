
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[Authorize]
[ApiController]
[Route("[controller]")]
public class GetStreamSessionsController(IRequestHandler<GetStreamSessionsResponse> requestHandler) : ControllerBase
{
    [HttpGet("/api/stream")]
    public IActionResult Get() => 
        Ok(requestHandler.Handle());
}
