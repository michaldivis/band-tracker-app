namespace BandTracker.UI.Views;

public partial class BandView : ContentPage
{
	private readonly BandViewModel _vm;

	public BandView(BandViewModel vm)
	{
		InitializeComponent();
        BindingContext = _vm = vm;
    }
}