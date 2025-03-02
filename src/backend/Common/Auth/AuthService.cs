using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

public interface IAuthService
{
    bool Authenticate(string username, string password);
    string GenerateToken(string username);
}
public class AuthService : IAuthService
{
    public bool Authenticate(string username, string password) =>
        username == "a" && password == "a";

    public string GenerateToken(string username)
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
            expires: DateTime.Now.AddMinutes(2),
            signingCredentials: creds);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}