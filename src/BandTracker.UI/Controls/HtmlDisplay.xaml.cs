using Microsoft.Extensions.Logging;
using System.Text.RegularExpressions;
using System.Windows.Input;

namespace BandTracker.UI.Controls;

public partial class HtmlDisplay : ContentView
{
    private readonly Guid _instanceId;
    private const string _baseUrl = "bandTracker_assets/";
    private readonly ILogger<HtmlDisplay> _logger;

    public static readonly BindableProperty HtmlContentProperty = BindableProperty.Create(nameof(HtmlContent), typeof(string), typeof(HtmlDisplay), propertyChanged: OnHtmlContentChanged);
    public string? HtmlContent
    {
        get => GetValue(HtmlContentProperty) as string;
        set => SetValue(HtmlContentProperty, value);
    }

    public static readonly BindableProperty LinkClickedCommandProperty = BindableProperty.Create(nameof(LinkClickedCommand), typeof(ICommand), typeof(HtmlDisplay));
    public ICommand? LinkClickedCommand
    {
        get => GetValue(LinkClickedCommandProperty) as ICommand;
        set => SetValue(LinkClickedCommandProperty, value);
    }

    public HtmlDisplay()
    {
        InitializeComponent();

        _instanceId = Guid.NewGuid();

        _logger = DI.Resolve<ILogger<HtmlDisplay>>();

        _logger.LogDebug("HtmlDisplay-{InstanceId}: Constructor", _instanceId);
    }

    static void OnHtmlContentChanged(BindableObject bindable, object oldValue, object newValue)
    {
        if (bindable is HtmlDisplay htmlDisplay)
        {
            if (newValue is string html)
            {
                //set html content
                htmlDisplay.SetHtmlSource(html);
            }
            else
            {
                //clear content
                htmlDisplay.SetHtmlSource(null);
            }
        }
    }

    private void SetHtmlSource(string? html)
    {
        var source = new HtmlWebViewSource()
        {
            BaseUrl = _baseUrl,
            Html = html
        };
        TheWebView.Source = source;
    }

    private void TheWebView_Navigating(object sender, WebNavigatingEventArgs e)
    {
        if (e.NavigationEvent != WebNavigationEvent.NewPage)
        {
            //unwanted navigation
            e.Cancel = true;
            return;
        }

        var link = GetClickedLinkFromUrl(e.Url);
        if (link is not null)
        {
            LinkClickedCommand?.TryExecute(link);
            e.Cancel = true;
            return;
        }
    }

    private async void TheWebView_Navigated(object sender, WebNavigatedEventArgs e)
    {
        //TODO the WebView.Navigated is never triggered for some reason

        if (_scrollToNext is not null)
        {
            await ScrollAsync(_scrollToNext);
            _scrollToNext = null;
        }

        if (_textToFind is not null)
        {
            await SearchAsync(_textToFind);
            _textToFind = null;
        }
    }

    #region Link clicks

    private static string? GetClickedLinkFromUrl(string url)
    {
        return DeviceInfo.Platform.ToString() switch
        {
            nameof(DevicePlatform.Android) => GetClickedLinkFromUrl_Android(url),
            nameof(DevicePlatform.iOS) => GetClickedLinkFromUrl_Ios(url),
            _ => throw new NotImplementedException()
        };
    }

    private static string? GetClickedLinkFromUrl_Android(string url)
    {
        //TODO detect link on Android. Current version only returns about:blank#blocked
        //GitHub Issue: https://github.com/dotnet/maui/issues/8648
        if (url == "about:blank#blocked")
        {
            return url;
        }

        return null;
    }

    private static readonly Regex _iosLinkRegex = new(@".*bandTracker_assets\/(?<link>.+)", RegexOptions.Singleline | RegexOptions.Compiled);

    private static string? GetClickedLinkFromUrl_Ios(string url)
    {
        if (url is null)
        {
            return null;
        }

        if (!url.Contains(_baseUrl))
        {
            return null;
        }

        var match = _iosLinkRegex.Match(url);

        if (!match.Success)
        {
            return null;
        }

        var link = match.Groups["link"].Value;

        return link;
    }

    #endregion

    #region ScrollTo

    private string? _scrollToNext = null;

    public async Task ScrollAsync(string? link)
    {
        if (link is null)
        {
            return;
        }

        string script = $"document.getElementById(\"{link}\").scrollIntoView();";
        var result = await TheWebView.EvaluateJavaScriptAsync(script);
        Console.WriteLine("HtmlDisplay-{0}: ScrollTo response: {1}", _instanceId, result);
    }

    public void ScrollOnNextLoad(string? elementId)
    {
        Console.WriteLine($"{nameof(ScrollOnNextLoad)}: {elementId}");
        _scrollToNext = elementId;
    }

    #endregion

    #region Search

    private string? _textToFind = null;

    public async Task SearchAsync(string? text)
    {
        Console.WriteLine($"{nameof(SearchAsync)}: {text}");

        var clean = CleanSearchText(text);
        if (string.IsNullOrEmpty(clean))
        {
            return;
        }

        //TODO highlight text in the entire document if possible
        var script = $"window.find('{clean}');";
        var result = await TheWebView.EvaluateJavaScriptAsync(script);
        Console.WriteLine("HtmlDisplay-{0}: Search response: {1}", _instanceId, result);
    }

    public void SearchOnNextLoad(string? text)
    {
        Console.WriteLine($"{nameof(SearchOnNextLoad)}: {text}");
        _textToFind = text;
    }

    private static string? CleanSearchText(string? text)
    {
        if (string.IsNullOrEmpty(text))
        {
            return null;
        }

        var clean = text.Replace("'", "");

        if (string.IsNullOrEmpty(clean))
        {
            return null;
        }

        return clean;
    }

    #endregion
}
