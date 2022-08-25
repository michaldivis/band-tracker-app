namespace BandTracker.UI.Views;

public partial class ViewBase : ContentPage
{
	protected readonly VmBase _vm;

	public IList<IView> PageContent => PageContentGrid.Children;

	public ViewBase(VmBase vm)
	{
        InitializeComponent();
        BindingContext = _vm = vm;
	}

	protected override async void OnAppearing()
	{
		await _vm.OnInitializedAsync();
	}
}