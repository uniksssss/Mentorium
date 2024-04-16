namespace Mentorium;

public class Configuration
{
    public string? ClientId { get; } = Environment.GetEnvironmentVariable("CLIENT_ID");
    public string? ClientSecret { get; } = Environment.GetEnvironmentVariable("CLIENT_SECRET");
    public string? DatabaseHost { get; } = Environment.GetEnvironmentVariable("DB_HOST");
    public string? DatabasePort { get; } = Environment.GetEnvironmentVariable("DB_PORT");
    public string? DatabaseName { get; } = Environment.GetEnvironmentVariable("DB_NAME");
    public string? DatabaseUsername { get; } = Environment.GetEnvironmentVariable("DB_USERNAME");
    public string? DatabasePassword { get; } = Environment.GetEnvironmentVariable("DB_PASSWORD");

    public string ConnectionString => 
        $"Host={DatabaseHost};port={DatabasePort};Database={DatabaseName};Username={DatabaseUsername};Password={DatabasePassword}";
}