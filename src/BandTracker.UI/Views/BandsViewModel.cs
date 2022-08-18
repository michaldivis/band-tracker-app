using System.Collections.ObjectModel;

namespace BandTracker.UI.Views;
public partial class BandsViewModel : VmBase
{
    private readonly IBandRepository _bandRepository;

    private readonly IReadOnlyList<Band> _allBands;

    public ObservableCollection<Band> Bands { get; }
    public ObservableCollection<string> Genres { get; }

    public BandsViewModel(IBandRepository bandRepository)
    {
        _bandRepository = bandRepository;

        _allBands = _bandRepository.GetAll();
        Bands = new(_allBands);

        var genres = _bandRepository.GetGenres();
        Genres = new(genres);
    }

    [RelayCommand]
    private void ReloadBands(IEnumerable<string>? genres = null)
    {
        if (genres is null || !genres.Any())
        {
            Bands.ReplaceRange(_allBands);
            return;
        }

        var filteredBands = _allBands.Where(a => genres.Intersect(a.Genres).Any());
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
