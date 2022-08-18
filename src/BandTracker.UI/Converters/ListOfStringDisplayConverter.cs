using System.Globalization;

namespace BandTracker.UI.Converters;

public class ListOfStringDisplayConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is not List<string> items)
        {
            return value;
        }

        return string.Join(", ", items);
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return value;
    }
}
