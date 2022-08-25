using Microsoft.Extensions.Logging;

namespace BandTracker.UI.Views;

[QueryProperty(nameof(ArtistName), nameof(ArtistName))]
[QueryProperty(nameof(Release), nameof(Release))]
public partial class ReleaseViewModel : VmBase
{
    private readonly ImageColorReader _imageColorReader;
    private readonly ILogger<ReleaseViewModel> _logger;

    [ObservableProperty]
    private string? _artistName;

    [ObservableProperty]
    private Release? _release;

    [ObservableProperty]
    private Brush _backgroundBrush = new SolidColorBrush(Colors.Transparent);

    public ReleaseViewModel(ImageColorReader imageColorReader, ILogger<ReleaseViewModel> logger)
    {
        _imageColorReader = imageColorReader;
        _logger = logger;
    }

    public override async Task OnInitializedAsync()
    {
        await SetBackgroundGradientAsync(Release?.ArtImageUrl);
    }

    private async Task SetBackgroundGradientAsync(string? artImageUrl)
    {
        var result = await _imageColorReader.GetAverageColorAsync(artImageUrl);

        if (!result.IsSuccess)
        {
            _logger.LogError("Failed to load gradient color from artwork: {@Errors}", result.Errors);
            return;
        }

        var averageColor = Color.FromRgb(result.Value.R, result.Value.G, result.Value.B);

        var gradient = new LinearGradientBrush
        {
            GradientStops = new()
            {
                new GradientStop(averageColor, 0.1f),
                new GradientStop(Colors.Transparent, 1.0f)
            }
        };

        BackgroundBrush = gradient;
    }
}