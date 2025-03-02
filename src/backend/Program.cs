using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{    
    options.AddPolicy("AllowLocalhost",
        builder => builder.SetIsOriginAllowed(origin => new Uri(origin).Host == "localhost")
            .AllowCredentials()
            .AllowAnyMethod()
            .AllowAnyHeader());
});

//var signatureSecret = builder.Configuration.GetValue<string>("signatureSecret")!.ToString();
var authConfig = builder.Configuration.GetSection("Auth").Get<AuthServiceOptions>()!;
builder.Services.AddTokenAuthorization(authConfig);

builder.Services.AddDbContext<StreamSessionContext>(options =>
    options.UseMySql("Server=localhost;Database=StreamSessionsDb;User=root;Password=mucho-secreto;", new MySqlServerVersion(new Version(8, 0, 21))));


//builder.Configuration.GetSection(nameof(AuthServiceOptions))
//    .Bind(options);
builder.Services.Configure<AuthServiceOptions>(builder.Configuration.GetSection("Auth"));

builder.Services.AddSingleton<IAuthService,AuthService>();
builder.Services.AddScoped<INotificationService, NotificationService>();
builder.Services.AddScoped<IQueryHandler<GetAccessTokenRequest, GetAccessTokenResponse>, GetAccessTokenHandler>();
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
app.MapHub<NotificationHub>("/notification");

app.Run();
