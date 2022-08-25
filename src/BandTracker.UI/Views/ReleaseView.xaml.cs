namespace BandTracker.UI.Views;

public partial class ReleaseView : ContentPage
{
    private readonly ReleaseViewModel _vm;

    public ReleaseView(ReleaseViewModel vm)
    {
        InitializeComponent();
        BindingContext = _vm = vm;
    }

    protected override async void OnAppearing()
    {
        await _vm.OnInitializedAsync();
    }
}
