using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

public interface IAuthService
{
    bool Authenticate(string username, string password);
    string GenerateToken(string username);
}
public class AuthServiceOptionsUser
{
    public string Username { get; init; } = string.Empty;
    public string Password { get; init; } = string.Empty;
}
public class AuthServiceOptions
{
    public const string SectionName = "Auth";
    
    public string DomainName { get; init; } = string.Empty;
    public int TokeDurationMin { get; init; }
    public string TokenSignatureSecret { get; init; } = string.Empty;
    public List<AuthServiceOptionsUser> Users { get; init; } = new List<AuthServiceOptionsUser>();
}
public class AuthService(IOptions<AuthServiceOptions> options) : IAuthService
{
    public bool Authenticate(string username, string password) =>
        options.Value.Users.Any(user => user.Username == username && user.Password == password);
    

    public string GenerateToken(string username)
    {
        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, username),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(options.Value.TokenSignatureSecret));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: options.Value.DomainName,
            audience: options.Value.DomainName,
            claims: claims,
            expires: DateTime.Now.AddMinutes(options.Value.TokeDurationMin),
            signingCredentials: creds);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}