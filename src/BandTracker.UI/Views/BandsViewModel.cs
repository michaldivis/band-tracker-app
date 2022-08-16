using BandTracker.Core.Services;
using System.Collections.ObjectModel;

namespace BandTracker.UI.Views;
public class BandsViewModel : ObservableObject
{
    public ObservableCollection<Band> Bands { get; }

	public BandsViewModel()
	{
		var bands = new BandRepository().GetAll();
        Bands = new(bands);
	}
}
