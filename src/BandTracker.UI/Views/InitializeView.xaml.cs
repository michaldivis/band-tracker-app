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

        await _vm.InitializeAppAsync();

        Application.Current.MainPage = new AppShell();
    }
}