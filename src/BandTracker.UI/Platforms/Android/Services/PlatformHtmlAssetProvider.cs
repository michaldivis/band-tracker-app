namespace BandTracker.UI.Services;
public class PlatformHtmlAssetProvider : IHtmlAssetProvider
{
    public string GetAssetsPath()
    {
        return "file:///android_asset/";
    }
}
