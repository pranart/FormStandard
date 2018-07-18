using System;
using FormStandard.Droid;
using Xamarin.Forms;

[assembly:Dependency(typeof(AppVersion))]
namespace FormStandard.Droid
{
    public class AppVersion : IAppVersion
    {
        public AppVersion()
        {
        }

        public string Version()
        {
            return Forms.Context.PackageManager.GetPackageInfo(Forms.Context.PackageName, 0).VersionName;
        }

    }
}
