using System;
namespace FormStandard
{
    public interface ILocation
    {
        bool IsGpsEnabled();
        bool IsNetworkEnabled();

        bool IsLocationEnabled();
    }
}
