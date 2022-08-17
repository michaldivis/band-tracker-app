namespace BandTracker.Core.Bands;

public class FullShow
{
    public Guid ShowId { get; init; }

    public string ArtistName { get; init; } = null!;
    public string ArtistAvatarImageUrl { get; init; } = null!;

    public DateTime Date { get; init; }
    public string Location { get; init; } = null!;

    public override string ToString()
    {
        return $"{Location} - {Date}";
    }
}
