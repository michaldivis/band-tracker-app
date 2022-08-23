using System.Windows.Input;

namespace BandTracker.Core.Extensions;

public static class ICommandExtensions
{
    public static void TryExecute(this ICommand command, object? parameter = null)
    {
        if(command is null)
        {
            return;
        }

        if (command.CanExecute(parameter))
        {
            command.Execute(parameter);
        }
    }
}
