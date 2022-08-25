using SkiaSharp;
using System.Drawing;

namespace BandTracker.Core.Utils;
public class ImageColorReader
{
    private readonly IHttpClientFactory _httpClientFactory;

    public ImageColorReader(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<Result<Color>> GetAverageColorAsync(string? imageUrl)
	{
        if (string.IsNullOrEmpty(imageUrl))
        {
            return Result.Fail("Image URL is null or empty");
        }

		try
		{
            var httpClient = _httpClientFactory.CreateClient();
            var imageStream = await httpClient.GetStreamAsync(imageUrl).ConfigureAwait(false);
            var image = SKBitmap.Decode(imageStream);

            if (image is null)
            {
                return Result.Fail("Failed to load image from URL");
            }

            var r = image.Pixels.Sum(a => a.Red) / image.Pixels.Length;
            var g = image.Pixels.Sum(a => a.Green) / image.Pixels.Length;
            var b = image.Pixels.Sum(a => a.Blue) / image.Pixels.Length;

            return Color.FromArgb(r, g, b);
        }
		catch (Exception ex)
		{
            return Result.Fail(new Error("Average color detection failed").CausedBy(ex));
        }
    }
}
