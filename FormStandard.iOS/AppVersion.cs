using Foundation;
using Xamarin.Forms;

[assembly: Dependency(typeof(FormStandard.iOS.AppVersion))]
namespace FormStandard.iOS
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
