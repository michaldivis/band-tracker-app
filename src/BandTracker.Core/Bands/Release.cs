namespace BandTracker.Core.Bands;
public class Release
{
    public Guid ReleaseId { get; init; }
    public Band Author { get; init; } = null!;

    public string Name { get; init; } = null!;
    public List<Track> Tracks { get; init; } = new();
}
