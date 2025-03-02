using Microsoft.EntityFrameworkCore;

public class DatabaseOptions
{
    public const string SectionName = "Database";

    public string Server { get; init; } = string.Empty;
    public string DatabaseName { get; init; } = string.Empty;
    public string User { get; init; } = string.Empty;
    public string Password { get; init; } = string.Empty;
}
public static class DatabaseServiceExtensions
{
    public static IServiceCollection AddMysqlDatabase(this IServiceCollection services, DatabaseOptions dbDptions)
    {
        var connectionString = $"Server={dbDptions.Server};Database={dbDptions.DatabaseName};User={dbDptions.User};Password={dbDptions.Password};";
        services.AddDbContext<StreamSessionContext>(options =>
            options.UseMySql(connectionString, new MySqlServerVersion(new Version(8, 0, 21))));

        return services;
    }
}