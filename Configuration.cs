namespace Mentorium;

public class Configuration
{
    public string? ClientId { get; } = Environment.GetEnvironmentVariable("CLIENT_ID")!;
    public string? ClientSecret { get; } = Environment.GetEnvironmentVariable("CLIENT_SECRET")!;
}