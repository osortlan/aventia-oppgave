var builder = WebApplication.CreateBuilder(args);

var allowedOrigin = builder.Configuration.GetValue<string>("AllowedOrigin");
builder.Services.AddCors(options =>
{    
    options.AddPolicy("AllowLocalhost",
        builder => builder.SetIsOriginAllowed(origin => new Uri(origin).Host == allowedOrigin)
            .AllowCredentials()
            .AllowAnyMethod()
            .AllowAnyHeader());
});

builder.Services.AddTokenAuthorization(
    builder.Configuration.GetSection(AuthServiceOptions.SectionName).Get<AuthServiceOptions>()!
);

builder.Services.AddMysqlDatabase(
    builder.Configuration.GetSection(DatabaseOptions.SectionName).Get<DatabaseOptions>()!
);

builder.Services.Configure<AuthServiceOptions>(builder.Configuration.GetSection(AuthServiceOptions.SectionName));

builder.Services.AddSingleton<IAuthService,AuthService>();
builder.Services.AddSingleton<INotificationService, NotificationService>();
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