namespace BandTracker.Core.Html;
public class HtmlUtilityService : IHtmlUtilityService
{
    private readonly IHtmlAssetProvider _htmlAssetProvider;

    public HtmlUtilityService(IHtmlAssetProvider htmlAssetProvider)
    {
        _htmlAssetProvider = htmlAssetProvider;
    }

    public string GetFullHtmlPage(string content)
    {
        var htmlAssetDirectory = _htmlAssetProvider.GetAssetsPath();
        var fullHtmlPage = GetFullHtmlPage(htmlAssetDirectory, content);
        return fullHtmlPage;
    }

    private static string GetFullHtmlPage(string htmlAssetDirectory, string content)
    {
        return $@"
	    <!DOCTYPE html>
            <html lang=""en"">
            <head>
                <meta charset=""UTF-8"">
                <meta http-equiv=""X-UA-Compatible"" content=""IE=edge"">
                <meta name=""viewport"" content=""width=device-width, initial-scale=1.0"">
                <title>Artist Description</title>
                <link rel=""stylesheet"" href=""{htmlAssetDirectory}desc.css"">
            </head>
            <body>
                {content}
            </body>
        </html>
        ";
    }
}
