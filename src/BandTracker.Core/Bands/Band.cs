namespace BandTracker.Core.Bands;
public class Band
{
    public string ArtistId { get; init; } = null!;
    public string Name { get; init; } = null!;
    public List<string> Genres { get; init; } = null!;
    public string AvatarImageUrl { get; init; } = null!;
    public int Followers { get; init; }
    public List<Release> Releases { get; init; } = new();
    public List<Show> Shows { get; init; } = new();

    public IEnumerable<Release> Albums => Releases.Where(a => a.ReleaseType == "album");
    public IEnumerable<Release> Singles => Releases.Where(a => a.ReleaseType == "single");

    public override string ToString()
    {
        return Name;
    }
}