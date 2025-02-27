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
    public string Post(GetTokenRequest request)
    {
        return "Hello-World";
    }
}
