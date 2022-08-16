using System.Collections.ObjectModel;

namespace BandTracker.UI.Views;
public class BandsViewModel : ObservableObject
{
    public ObservableCollection<Band> Bands { get; }

	public BandsViewModel()
	{
		var bandsRepository = DI.Resolve<IBandRepository>();
        var bands = bandsRepository.GetAll();
        Bands = new(bands);
	}
}
