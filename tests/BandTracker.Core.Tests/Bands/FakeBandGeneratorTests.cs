namespace BandTracker.Core.Bands;
public class FakeBandGeneratorTests
{
	private readonly FakeBandGenerator _sut;

    public FakeBandGeneratorTests()
	{
        _sut = new();
    }

    [Fact]
    public void Generate_ShouldCreate100BandsInLessThanASecond()
    {
        var stopwatch = System.Diagnostics.Stopwatch.StartNew();

        _ = _sut.Generate(100);

        stopwatch.Stop();

        stopwatch.Elapsed.Should().BeLessThan(TimeSpan.FromSeconds(1));
    }

    [Fact]
    public void Generate_ShouldCreateValidBands()
    {
        var bands = _sut.Generate(100);

        foreach (var band in bands)
        {
            band.BandId.Should().NotBeEmpty();
            band.Name.Should().NotBeNullOrEmpty();
            band.AvatarImageUrl.Should().NotBeNullOrEmpty();
            band.BackgroundImageUrl.Should().NotBeNullOrEmpty();
            band.Releases.Should().NotBeEmpty();
        }
    }
}
