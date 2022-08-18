namespace BandTracker.UI.Views;

public partial class InitializeView : ContentPage
{
	private readonly InitializeViewModel _vm;

    public InitializeView()
	{
		InitializeComponent();
		BindingContext = _vm = new(DI.Resolve<IBandRepository>());
	}

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        var progress = new Progress<string>(text => _vm.ProgressText = text);

        await _vm.InitializeAppAsync(progress);
    }
}