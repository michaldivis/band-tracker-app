namespace BandTracker.Core.Bands;
public class Release
{
    public Guid ReleaseId { get; init; }
    public Band Author { get; set; } = null!;

    public string Name { get; init; } = null!;
    public DateTime ReleaseDate { get; init; }
    public string ArtImageUrl { get; init; } = null!;
    public List<Track> Tracks { get; init; } = new();

    public string ReleaseType => GetReleaseType();

    public override string ToString()
    {
        return $"{Name} ({ReleaseType}) - {Tracks.Count} tracks";
    }

    private string GetReleaseType()
    {
        if(Tracks.Count > 6 && Tracks.Sum(a => a.Length.Minutes) > 30)
        {
            return "Album";
        }

        if (Tracks.Count > 1)
        {
            return "EP";
        }

        return "Single";
    }
}
