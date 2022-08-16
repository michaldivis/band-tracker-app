using Bogus;

namespace BandTracker.Core.Bands;
public class FakeBandGenerator
{
    private readonly Faker<Band> _bandFaker;
    private readonly Faker<Release> _releaseFaker;
    private readonly Faker<Track> _trackFaker;

    private const string _avatarPlaceholder = "band.jpg";
    private const string _artPlaceholder = "album.jpg";

    public FakeBandGenerator()
    {
        _bandFaker = new Faker<Band>()
            .RuleFor(a => a.BandId, Guid.NewGuid())
            .RuleFor(a => a.Name, f => f.Company.CompanyName())
            .RuleFor(a => a.Genre, f => f.Music.Genre())
            .RuleFor(a => a.AvatarImageUrl, f => _avatarPlaceholder)
            .RuleFor(a => a.Releases, (f, band) => GenerateReleases(band, f.Random.Int(1, 10)));

        _releaseFaker = new Faker<Release>()
            .RuleFor(a => a.ReleaseId, Guid.NewGuid())
            .RuleFor(a => a.Name, f => f.Commerce.ProductName())
            .RuleFor(a => a.ReleaseDate, f => f.Date.Past(10, DateTime.Now))
            .RuleFor(a => a.ArtImageUrl, f => _artPlaceholder)
            .RuleFor(a => a.Tracks, (f, release) => GenerateTracks(release, f.Random.Int(1, 15)));

        _trackFaker = new Faker<Track>()
            .RuleFor(a => a.TrackId, Guid.NewGuid())
            .RuleFor(a => a.Name, f => f.Commerce.ProductName())
            .RuleFor(a => a.Length, f => TimeSpan.FromSeconds(f.Random.Int(60, 300)));
    }

    public List<Band> Generate(int amount)
    {
        return _bandFaker.Generate(amount);
    }

    private List<Release> GenerateReleases(Band author, int amount)
    {
        var releases = _releaseFaker.Generate(amount);
        releases.ForEach(a => a.Author = author);
        return releases;
    }

    private List<Track> GenerateTracks(Release release, int amount)
    {
        var tracks = _trackFaker.Generate(amount);
        tracks.ForEach(a => a.Release = release);
        return tracks;
    }
}
