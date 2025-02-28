using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

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
        if(Authenticate(request.username, request.password))
            return Ok(new GetTokenResponse(GenerateToken(request.username,request.username)));
        return BadRequest("Wrong username or password");
    }

    [HttpGet("/api/auth/test")]
    public IActionResult Get()
    {
        return Ok();
    }

    private bool Authenticate(string username, string password) =>
        username == "a" && password == "a";
    
    private string GenerateToken(string id, string email)
    {
        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, id),
            new Claim(JwtRegisteredClaimNames.Email, email),
            // Add more claims if needed
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("very-very-very-secret-keyiuhvzkuibrfgusrgusgbsbigbigsurhbgubskug"));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: "tralala.no",
            audience: "Aventia AS",
            claims: claims,
            expires: DateTime.Now.AddMinutes(5),//DateTime.Now.AddDays(_config.ExpireDays),
            signingCredentials: creds
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}