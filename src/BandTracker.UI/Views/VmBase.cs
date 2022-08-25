namespace BandTracker.UI.Views;

public partial class VmBase : ObservableObject
{
    [RelayCommand]
    private async Task GoBackAsync()
    {
        await Shell.Current.GoToAsync("..", true);
    }

    public virtual Task OnInitializedAsync()
    {
        return Task.CompletedTask;
    }
}
