namespace BandTracker.Core.Models;
public class Track
{
    public Guid TrackId { get; init; }
    public Release Release { get; init; } = null!;

    public string Name { get; init; } = null!;
    public TimeSpan Length { get; init; }
}
