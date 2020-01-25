using System;
using FormStandard.Droid;
using Xamarin.Forms;
using FormStandard;

[assembly: Dependency(typeof(Navigate))]
namespace FormStandard.Droid
{
    public class Navigate : INavigate
    {
        public Navigate()
        {
        }

        public void NavigateTo(double latitude, double longitude, double fromLatitude = 0.0, double fromLongitude = 0.0)
        {

            var request = string.Format("http://maps.google.com/?daddr=" + latitude.ToString() + "," + longitude.ToString() + "");

            Device.OpenUri(new Uri(request));

        }
    }
}

