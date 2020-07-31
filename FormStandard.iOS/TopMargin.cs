using System;
using FormStandard;
using UIKit;
using Xamarin.Forms;

[assembly: Dependency(typeof(FormStandard.iOS.TopMargin))]

namespace FormStandard.iOS
{
    public class TopMargin : ITopMargin
    {
        public TopMargin()
        {

        }

        public Thickness GetTopMargin()
        {
            var KeyWindow = UIApplication.SharedApplication?.KeyWindow;
            if (KeyWindow == null)
                return new Thickness(0,20,0,0);
                
            var margin = (int)KeyWindow.SafeAreaInsets.Top;
            if (margin == 0) return new Thickness(0, 20, 0, 0);


            return new Thickness(0,margin,0,0);
               
        }
    }
}
