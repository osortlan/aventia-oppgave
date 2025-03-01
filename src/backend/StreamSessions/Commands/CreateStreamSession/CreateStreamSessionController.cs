
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[Authorize]
[ApiController]
[Route("[controller]")]
public class CreateStreamSessionController(ICommandHandler<CreateStreamSessionRequest> commandHandler) : ControllerBase
{
    [HttpPost("/api/stream")]
    public IActionResult Post([FromBody]CreateStreamSessionRequest request)
    {
        commandHandler.Handle(request);
        return Ok();
    }        
}
