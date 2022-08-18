using BandTracker.UI.Views;

namespace BandTracker.UI;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();

        MainPage = new InitializeView();
    }
}