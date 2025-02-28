using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace backend.Auth;

[ApiController]
[Route("[controller]")]
public class AuthController : ControllerBase
{
    private readonly ILogger<AuthController> _logger;

    public AuthController(ILogger<AuthController> logger)
    {
        _logger = logger;
    }

    [HttpPost("/api/auth/login")]
    public IActionResult Post(GetTokenRequest request)
    {
        if(request.username == "a" && request.password == "b")
            return Ok(new GetTokenResponse("Hello-World"));
        return Unauthorized("Wrong username or password");
    }
}
