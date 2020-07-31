using System;
using FormStandard;
using Xamarin.Forms;

[assembly:Dependency(typeof(FormStandard.Droid.TopMargin))]

namespace FormStandard.Droid
{
    public class TopMargin : ITopMargin
    { 
        public TopMargin()
        {
        }

        public Thickness GetTopMargin()
        {
            if(Android.OS.Build.VERSION.SdkInt >= Android.OS.BuildVersionCodes.P)
            {
                return new Thickness(0,20,0,0);
            }
            return new Thickness(0, 20, 0, 0);

        }
    }
}
