namespace BandTracker.Core.Bands;
public class Release
{
    public string AlbumId { get; init; } = null!;
    public string Name { get; init; } = null!;
    public string ReleaseType { get; init; } = null!;
    public DateTime ReleaseDate { get; init; }
    public string ArtImageUrl { get; init; } = null!;
    public List<Track> Tracks { get; init; } = new();
    public string DisplayReleaseType => GetDisplayReleaseType();

    public override string ToString()
    {
        return $"{Name} ({ReleaseType}) - {Tracks.Count} tracks";
    }

    private string GetDisplayReleaseType()
    {
        if(ReleaseType == "album")
        {
            return "album";
        }

        if(Tracks.Count > 3)
        {
            return "EP";
        }

        return "single";
    }
}
