
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[Authorize]
[ApiController]
[Route("[controller]")]
public class GetStreamSessionsController(IQueryHandler<GetStreamSessionsResponse> queryHandler) : ControllerBase
{
    [HttpGet("/api/stream")]
    public IActionResult Get() => 
        Ok(queryHandler.Handle());
}
