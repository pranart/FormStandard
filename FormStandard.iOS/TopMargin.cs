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
            int x = 0;
        }

        public int GetTopMargin()
        {
            var margin = (int)UIApplication.SharedApplication?.KeyWindow?.SafeAreaInsets.Top;
            if (margin == 0) margin = 20;
            else margin -= 20;
            return margin;
               
        }
    }
}
