namespace BandTracker.UI.Views;

[QueryProperty("Band", "BandToOpen")]
public partial class BandViewModel : VmBase
{
    private readonly IHtmlUtilityService _htmlUtilityService;

    [ObservableProperty]
    private Band? _band;    

    [ObservableProperty]
    private string? _htmlDescription;

    public BandViewModel(IHtmlUtilityService htmlUtilityService)
    {
        _htmlUtilityService = htmlUtilityService;

        HtmlDescription = htmlUtilityService.GetFullHtmlPage(RawBandsHtml.DemoArtistBio);
    }

    [RelayCommand]
    private async Task GoToReleaseAsync(Release release)
    {
        await Shell.Current.GoToAsync(nameof(ReleaseView), true, new Dictionary<string, object>
        {
            { nameof(ReleaseViewModel.ArtistName), Band?.Name },
            { nameof(ReleaseViewModel.Release), release }
        });
    }
}