using Microsoft.Extensions.DependencyInjection;

namespace BandTracker.Core.Utils;
public class ImageColorReaderTests
{
    private readonly ImageColorReader _sut;

    public ImageColorReaderTests()
    {
        var httpClient = new ServiceCollection()
            .AddHttpClient()
            .BuildServiceProvider()
            .GetRequiredService<IHttpClientFactory>();

        _sut = new(httpClient);
    }

    [Fact]
    public async Task GetAverageColorAsync_ShouldFail_WhenImageUrlIsNull()
    {
        var result = await _sut.GetAverageColorAsync(null!);
        result.IsSuccess.Should().BeFalse();
    }

    [Fact]
    public async Task GetAverageColorAsync_ShouldReturnBlack_WhenImageUrlIsEmpty()
    {
        var result = await _sut.GetAverageColorAsync(string.Empty);
        result.IsSuccess.Should().BeFalse();
    }

    [Fact]
    public async Task GetAverageColorAsync_ShouldReturnBlack_WhenImageUrlIsInvalid()
    {
        var result = await _sut.GetAverageColorAsync("https://www.example.com/non_existing_image.jpg");
        result.IsSuccess.Should().BeFalse();
    }

    [Theory]
    [InlineData("https://picsum.photos/id/237/200/300", 65, 58, 52)]
    public async Task GetAverageColorAsync_SholuldWork(string imageUrl, byte expectedR, byte expectedG, byte expectedB)
    {
        var result = await _sut.GetAverageColorAsync(imageUrl);
        result.IsSuccess.Should().BeTrue();
        result.Value.R.Should().Be(expectedR);
        result.Value.G.Should().Be(expectedG);
        result.Value.B.Should().Be(expectedB);
    }
}
