namespace BandTracker.UI.Views;

public partial class RecentReleasesView : ContentPage
{
    private readonly RecentReleasesViewModel _vm;

    public RecentReleasesView(RecentReleasesViewModel vm)
	{
		InitializeComponent();
        BindingContext = _vm = vm;
    }
}
