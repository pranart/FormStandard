using System;
using Android.Locations;
using Xamarin.Forms;

[assembly: Dependency(typeof(FormStandard.Droid.Location))]
namespace FormStandard.Droid
{
    public class Location : ILocation
    {
        LocationManager LocationManager { get; set; }
        public Location()
        {
            LocationManager = (LocationManager)Forms.Context.GetSystemService(Forms.Context.LocationService);

        }

        public bool IsGpsEnabled()
        {
            try
            {
                return LocationManager.IsProviderEnabled(LocationManager.GpsProvider);
            }
            catch(Exception) 
            {
                return false;
            }

        }

        public bool IsLocationEnabled()
        {
            try
            {
                return LocationManager.IsProviderEnabled(LocationManager.NetworkProvider);
            }
            catch (Exception)
            {
                return false;
            }

        }

        public bool IsNetworkEnabled()
        {
            return IsGpsEnabled() || IsNetworkEnabled();                                                                        
        }
    }
}
