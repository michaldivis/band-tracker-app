namespace BandTracker.UI.Views;

public partial class DashboardView : ContentPage
{
	private readonly DashboardViewModel _vm;

	public DashboardView(DashboardViewModel vm)
	{
		InitializeComponent();
        BindingContext = _vm = vm;
	}
}