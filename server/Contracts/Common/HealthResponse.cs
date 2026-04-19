namespace server.Contracts.Common;

public sealed class HealthResponse
{
    public string Status { get; init; } = default!;
    public string Service { get; init; } = default!;
    public DateTime UtcTime { get; init; }
}