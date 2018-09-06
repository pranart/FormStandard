using System;
using CoreLocation;
using Xamarin.Forms;

[assembly:Dependency(typeof(FormStandard.iOS.Location))]
namespace FormStandard.iOS
{
	public class Location : ILocation
    {
        public Location()
        {
        }

        public bool IsGpsEnabled()
        {
            return CLLocationManager.LocationServicesEnabled;
        }

        public bool IsLocationEnabled()
        {
            return CLLocationManager.LocationServicesEnabled;
        }

        public bool IsNetworkEnabled()
        {
            return CLLocationManager.LocationServicesEnabled;
        }
    }
}
