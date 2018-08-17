using System;
using FormStandard.iOS;
using Xamarin.Forms;

[assembly:Dependency(typeof(Navigate))]
namespace FormStandard.iOS
{
    public class Navigate : INavigate
    {
        public Navigate()
        {
        }

        public void NavigateTo(double latitude, double longitude,double fromLatitude=0.0,double fromLongitude=0.0)
        {
            

            string url =string.Format("http://maps.apple.com/?saddr={0},{1}&daddr={2},{3}", fromLatitude, fromLongitude, latitude, longitude);
                Device.BeginInvokeOnMainThread(()=>Device.OpenUri(new Uri(url)));
           
        }
    }
}
