using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

public static class AuthServiceExtensions
{
    public static IServiceCollection AddTokenAuthorization(this IServiceCollection services)
    {
        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.UseSecurityTokenValidators = true;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = "yourdomain.com",
                    ValidAudience = "yourdomain.com",
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("hoihgihoisrhgoioiuaoarghirgpahguhagoiphrguhgapohgpohagphgpiahgrsghisuhgsoihgiouhsioghtsiuhgoihtriouhgioshgsigsihisuhgishtiushigtousihutgisuhitghsoig"))
                };
            });
        services.AddAuthorization();

        return services;
    }
}