using Foundation;
using Xamarin.Forms;

[assembly: Dependency(typeof(NeatLibrary.iOS.AppVersion))]
namespace NeatLibrary.iOS
{
    public class AppVersion : IAppVersion
    {
        public AppVersion()
        {
        }

        public string Version()
        {
            return NSBundle.MainBundle.InfoDictionary["CFBundleShortVersionString"].ToString();
        }
    }
}
