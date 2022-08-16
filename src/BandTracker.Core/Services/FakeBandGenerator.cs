using BandTracker.Core.Models;
using Bogus;

namespace BandTracker.Core.Services;
public class FakeBandGenerator
{
    private readonly Faker<Band> _bandFaker;

    public FakeBandGenerator()
    {
        _bandFaker = new Faker<Band>()
            .StrictMode(true)
            .RuleFor(a => a.BandId, Guid.NewGuid())
            .RuleFor(a => a.Name, f => f.Company.CompanyName())
            .RuleFor(a => a.AvatarImageUrl, f => f.Image.PicsumUrl(500, 500))
            .RuleFor(a => a.BackgroundImageUrl, f => f.Image.PicsumUrl(1920, 1080))
            .RuleFor(a => a.Releases, (f, band) => GenerateReleases(band, f.Random.Int(1, 10)));
    }

    public List<Band> Generate(int amount)
    {
        return _bandFaker.Generate(amount);
    }

    private List<Release> GenerateReleases(Band author, int amount)
    {
        return new Faker<Release>()
            .StrictMode(true)
            .RuleFor(a => a.ReleaseId, Guid.NewGuid())
            .RuleFor(a => a.Author, author)
            .RuleFor(a => a.Name, f => f.Commerce.ProductName())
            .RuleFor(a => a.Tracks, (f, release) => GenerateTracks(release, f.Random.Int(1, 15)))
            .Generate(amount);
    }

    private List<Track> GenerateTracks(Release release, int amount)
    {
        return new Faker<Track>()
            .StrictMode(true)
            .RuleFor(a => a.TrackId, Guid.NewGuid())
            .RuleFor(a => a.Release, release)
            .RuleFor(a => a.Name, f => f.Commerce.ProductName())
            .RuleFor(a => a.Length, f => TimeSpan.FromSeconds(f.Random.Int(60, 300)))
            .Generate(amount);
    }
}
