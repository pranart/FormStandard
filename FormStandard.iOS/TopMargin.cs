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

        public int GetTopMargin()
        {
            var KeyWindow = UIApplication.SharedApplication?.KeyWindow;
            if (KeyWindow == null) return 20;
            var margin = (int)KeyWindow.SafeAreaInsets.Top;
            if (margin == 0) margin = 20;

            return margin;
               
        }
    }
}
