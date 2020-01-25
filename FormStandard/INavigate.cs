using System;
namespace FormStandard
{
    public interface INavigate
    {
        void NavigateTo(double latitude, double longitude, double fromLatitude, double fromLongitude);
       // void NavigateTo(Xamarin.Forms.Maps.Position position, double lat, double lng);
    }
}
