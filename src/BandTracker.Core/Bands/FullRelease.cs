namespace BandTracker.Core.Bands;

public class FullRelease : Release
{
    public string ArtistName { get; init; } = null!;
    public string ArtistAvatarImageUrl { get; init; } = null!;

    public Release ToBasicRelease()
    {
        return new Release
        {
            AlbumId = AlbumId,
            ArtImageUrl = ArtImageUrl,
            ReleaseDate = ReleaseDate,
            ReleaseType = ReleaseType,
            Name = Name,
            Tracks = Tracks
        };
    }
}
