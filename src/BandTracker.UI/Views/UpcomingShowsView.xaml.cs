namespace BandTracker.UI.Views;

public partial class UpcomingShowsView : ContentPage
{
    private readonly UpcomingShowsViewModel _vm;

    public UpcomingShowsView(UpcomingShowsViewModel vm)
	{
		InitializeComponent();
        BindingContext = _vm = vm;
    }
}
