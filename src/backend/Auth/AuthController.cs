using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authorization;
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
        if(Authenticate(request.username, request.password))
            return Ok(new GetTokenResponse(GenerateToken(request.username,request.username)));
        return BadRequest("Wrong username or password");
    }

    [Authorize]
    [HttpGet("/api/auth/test")]
    public IActionResult Get()
    {
        return Ok();
    }

    private bool Authenticate(string username, string password) =>
        username == "a" && password == "a";
    
    private string GenerateToken(string id, string username)
    {
        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, username),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("hoihgihoisrhgoioiuaoarghirgpahguhagoiphrguhgapohgpohagphgpiahgrsghisuhgsoihgiouhsioghtsiuhgoihtriouhgioshgsigsihisuhgishtiushigtousihutgisuhitghsoig"));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: "yourdomain.com",
            audience: "yourdomain.com",
            claims: claims,
            expires: DateTime.Now.AddMinutes(30),
            signingCredentials: creds);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}