namespace BandTracker.UI.Views;

public partial class InitializeViewModel : VmBase
{
    private readonly IBandRepository _bandRepository;

    [ObservableProperty]
    private string? _progressText;

    public InitializeViewModel(IBandRepository bandRepository)
    {
        _bandRepository = bandRepository;
    }

    public async Task InitializeAppAsync()
    {
        ProgressText = "Loading artists";
        await _bandRepository.EnsureLoadedAsync();

        //pretend to load things...
        ProgressText = "Loading recent releases";
        await Task.Delay(500);
        ProgressText = "Loading upcoming shows";
        await Task.Delay(500);
        ProgressText = "Making coffee";
        await Task.Delay(500);
    }
}