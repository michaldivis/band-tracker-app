namespace BandTracker.Core.Bands;

public class FullRelease
{
    public string AlbumId { get; init; } = null!;

    public string ArtistName { get; init; } = null!;
    public string ArtistAvatarImageUrl { get; init; } = null!;

    public string Name { get; init; } = null!;
    public string ReleaseType { get; init; } = null!;
    public DateTime ReleaseDate { get; init; }
    public string ArtImageUrl { get; init; } = null!;
    public List<Track> Tracks { get; init; } = new();

    public override string ToString()
    {
        return $"{Name} ({ReleaseType}) - {Tracks.Count} tracks";
    }
}
