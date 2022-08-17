namespace BandTracker.Core.Bands;
public class Track
{
    public string TrackId { get; init; } = null!;
    public string Name { get; init; } = null!;
    public int TrackNumber { get; init; }

    public override string ToString()
    {
        return $"{TrackNumber} - {Name}";
    }
}
