namespace BandTracker.Core.Models;
public class Band
{
    public Guid BandId { get; init; }
    public string Name { get; init; } = null!;
    public string Genre { get; init; } = null!;
    public string AvatarImageUrl { get; init; } = null!;
    public string BackgroundImageUrl { get; init; } = null!;
    public List<Release> Releases { get; init; } = new();
}