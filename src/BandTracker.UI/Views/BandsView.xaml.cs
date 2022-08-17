namespace BandTracker.UI.Views;

public partial class BandsView : ContentPage
{
	private bool _isInitializing = true;

	public BandsView()
	{
		InitializeComponent();
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

		if(BindingContext is not BandsViewModel vm)
		{
			return;
		}

		var genres = fcgGenres.SelectedItems.Select(a => a.ToString()).ToList();

		if (vm.ReloadBandsCommand.CanExecute(genres))
		{
			vm.ReloadBandsCommand.Execute(genres);
        }
    }
}