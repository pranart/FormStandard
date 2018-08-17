using System;
using Foundation;
using FormStandard;
using FormStandard.iOS;
using Xamarin.Forms;
[assembly:Dependency(typeof(VersionOs))]
namespace FormStandard.iOS
{
    public class VersionOs : IVersionOs
    {
        public VersionOs()
        {
        }

        public int VersionNumber()
        {
            return (int)(NSProcessInfo.ProcessInfo.OperatingSystemVersion.Major * 10 + NSProcessInfo.ProcessInfo.OperatingSystemVersion.Minor);
        }

        public string VersionString()
        {
            return NSProcessInfo.ProcessInfo.OperatingSystemVersionString;
        }
    }
}
