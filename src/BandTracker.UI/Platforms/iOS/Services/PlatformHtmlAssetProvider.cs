using Foundation;

namespace BandTracker.UI.Services;
public class PlatformHtmlAssetProvider : IHtmlAssetProvider
{
    public string GetAssetsPath()
    {
        return NSBundle.MainBundle.BundlePath + "/";
    }
}
