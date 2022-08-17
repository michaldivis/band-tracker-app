namespace BandTracker.UI.Views;

public partial class BandsView : ContentPage
{
	private readonly BandsViewModel _vm;

	private bool _isInitializing = true;

	public BandsView(BandsViewModel vm)
	{
		InitializeComponent();
        BindingContext = _vm = vm;
    }

	protected override void OnAppearing()
	{
		base.OnAppearing();
    }

	protected override void OnSizeAllocated(double width, double height)
	{
		base.OnSizeAllocated(width, height);

        _isInitializing = false;
    }

	private void fcgGenres_SelectionChanged(object sender, EventArgs e)
	{
		if (_isInitializing)
		{
			return;
		}

		var genres = fcgGenres.SelectedItems.Select(a => a.ToString()).ToList();

		if (_vm.ReloadBandsCommand.CanExecute(genres))
		{
            _vm.ReloadBandsCommand.Execute(genres);
        }
    }
}