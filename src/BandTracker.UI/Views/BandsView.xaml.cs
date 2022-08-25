namespace BandTracker.UI.Views;

public partial class BandsView
{
	private bool _isInitializing = true;

	public BandsView(BandsViewModel vm) : base(vm)
	{
		InitializeComponent();
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

        ((BandsViewModel)_vm).ReloadBandsCommand.TryExecute(genres);
    }
}