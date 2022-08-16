using BandTracker.Core.Models;
using Bogus;

namespace BandTracker.Core.Services;
public class FakeBandGenerator
{
    private readonly Faker<Band> _bandFaker;
    private readonly Faker<Release> _releaseFaker;
    private readonly Faker<Track> _trackFaker;

    public FakeBandGenerator()
    {
        _bandFaker = new Faker<Band>()
            .StrictMode(true)
            .RuleFor(a => a.Name, f => f.Internet.UserName())
            .RuleFor(a => a.AvatarImageUrl, f => f.Internet.Avatar())
            .RuleFor(a => a.BackgroundImageUrl, f => f.Image.PicsumUrl(1920, 1080))
            .RuleFor(a => a.Releases, f => GenerateReleases(f.Random.Int(1, 10)));

        _releaseFaker = new Faker<Release>()
            .RuleFor(a => a.Name, f => f.Commerce.ProductName())
            .RuleFor(a => a.Tracks, f => GenerateTracks(f.Random.Int(1, 15)));

        _trackFaker = new Faker<Track>()
            .RuleFor(a => a.Name, f => f.Commerce.ProductName())
            .RuleFor(a => a.Length, f => TimeSpan.FromSeconds(f.Random.Int(60, 300)));
    }

    public IEnumerable<Band> Generate(int amount)
    {
        return _bandFaker.Generate(amount);
    }

    private IEnumerable<Release> GenerateReleases(int amount)
    {
        return _releaseFaker.Generate(amount);
    }

    private IEnumerable<Track> GenerateTracks(int amount)
    {
        return _trackFaker.Generate(amount);
    }
}
