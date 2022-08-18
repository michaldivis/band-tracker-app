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

    public async Task InitializeAppAsync(IProgress<string> progress)
    {
        progress.Report("Loading artists");
        await _bandRepository.EnsureLoadedAsync();

        //pretend to load things...
        progress.Report("Loading recent releases");
        await Task.Delay(500);
        progress.Report("Loading upcoming shows");
        await Task.Delay(500);
        progress.Report("Making coffee");
        await Task.Delay(500);

        Application.Current.MainPage = new AppShell();
    }
}