using System;
namespace FormStandard
{
    public interface INavigate
    {
        void NavigateTo(double latitude, double longitude, double fromLatitude, double fromLongitude);
    }
}
