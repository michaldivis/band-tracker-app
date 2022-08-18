using System.Globalization;

namespace BandTracker.UI.Converters;
public class ImageUrlToGradientConverter : IValueConverter
{
    private static readonly Lazy<ImageColorReader> _imageColorReader = new(() => DI.Resolve<ImageColorReader>());

    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (parameter is not Color gradientBaseColor)
        {
            return value;
        }

        if (value is not string imageUrl)
        {
            return new SolidColorBrush(gradientBaseColor);
        }

        var result = _imageColorReader.Value.GetAverageColorAsync(imageUrl).Result;

        if (!result.IsSuccess)
        {
            return new SolidColorBrush(gradientBaseColor);
        }

        var averageColor = Color.FromRgb(result.Value.R, result.Value.G, result.Value.B);

        return new LinearGradientBrush
        {
            GradientStops = new()
            {
                new GradientStop(averageColor, 0.1f),
                new GradientStop(gradientBaseColor, 1.0f)
            }
        };
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return value;
    }
}
