using System.Collections.ObjectModel;

namespace BandTracker.UI.Views;
public partial class BandsViewModel : VmBase
{
    private readonly IReadOnlyList<Band> _allBands;
    public ObservableCollection<Band> Bands { get; }
    public ObservableCollection<string> Genres { get; } = new();

    public BandsViewModel()
	{
		var bandsRepository = DI.Resolve<IBandRepository>();
        _allBands = bandsRepository.GetAll();

        Bands = new(_allBands);

        Genres.ReplaceRange(_allBands.Select(a => a.Genre).Distinct());
    }

    [RelayCommand]
    private void ReloadBands(IEnumerable<string>? genres = null)
    {
        if (genres is null || !genres.Any())
        {
            Bands.ReplaceRange(_allBands);
            return;
        }

        var filteredBands = _allBands.Where(a => genres.Contains(a.Genre));
        Bands.ReplaceRange(filteredBands);
    }

    [RelayCommand]
    private async Task GoToBandAsync(Band band)
    {
        await Shell.Current.GoToAsync(nameof(BandView), true, new Dictionary<string, object>
        {
            { "BandToOpen", band }
        });
    }
}
