using System;
using Xamarin.Forms;

namespace FormStandard
{
    public class StandardSafeView : View
    {
        public StandardSafeView()
        {
            BackgroundColor = Color.Transparent;
        }
        public object NativeView { get; set; }
    }
}
