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

        public int GetTopMargin()
        {
            if(Android.OS.Build.VERSION.SdkInt >= Android.OS.BuildVersionCodes.P)
            {
                return 20;
            }
            return 20;
        }
    }
}
