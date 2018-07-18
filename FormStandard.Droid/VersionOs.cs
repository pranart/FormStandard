using System;
using Xamarin.Forms;
using FormStandard;
using FormStandard.Droid;

[assembly:Dependency(typeof(VersionOs))]
namespace FormStandard.Droid
{
    public class VersionOs : IVersionOs
    {
        public VersionOs()
        {
        }

        public int VersionNumber()
        {
            return (int)Android.OS.Build.VERSION.SdkInt;
        }

        public string VersionString()
        {
            return Android.OS.Build.VERSION.Release;
        }
    }
}
