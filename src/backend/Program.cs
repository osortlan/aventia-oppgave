using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{    
    options.AddPolicy("AllowLocalhost",
        builder => builder.SetIsOriginAllowed(origin => new Uri(origin).Host == "localhost")
            .AllowAnyMethod()
            .AllowAnyHeader());
});

//var signatureSecret = builder.Configuration.GetValue<string>("signatureSecret")!.ToString();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
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
builder.Services.AddAuthorization();

builder.Services.AddDbContext<StreamSessionContext>(options =>
    options.UseMySql("Server=localhost;Database=StreamSessionsDb;User=root;Password=mucho-secreto;", new MySqlServerVersion(new Version(8, 0, 21))));

builder.Services.AddScoped<IQueryHandler<GetStreamSessionsResponse>, GetStreamSessionsHandler>();
builder.Services.AddScoped<ICommandHandler<CreateStreamSessionRequest>, CreateStreamSessionHandler>();

builder.Services.AddControllers();
builder.Services.AddSignalR();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseDeveloperExceptionPage();
}

//app.UseHttpsRedirection();

app.UseCors("AllowLocalhost");

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.MapHub<ChatHub>("/chatHub");

app.Run();
