namespace BandTracker.Core.Bands;
public class Band
{
    public Guid BandId { get; init; }
    public string Name { get; init; } = null!;
    public string Genre { get; init; } = null!;
    public string AvatarImageUrl { get; init; } = null!;
    public int Followers { get; init; }
    public int MonthlyListeners { get; init; }
    public List<Release> Releases { get; init; } = new();
    public List<Show> Shows { get; init; } = new();

    public override string ToString()
    {
        return Name;
    }
}