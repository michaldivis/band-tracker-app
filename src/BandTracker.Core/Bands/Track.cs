namespace BandTracker.Core.Bands;
public class Track
{
    public Guid TrackId { get; init; }
    public Release Release { get; set; } = null!;

    public string Name { get; init; } = null!;
    public TimeSpan Length { get; init; }

    public override string ToString()
    {
        return $"{Name} - {Length}";
    }
}
