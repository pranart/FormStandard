using System;
using UIKit;
using NeatLibrary;
using Xamarin.Forms.Platform.iOS;
using NeatLibrary.iOS;
using Xamarin.Forms;
using CoreGraphics;

[assembly: ExportRenderer(typeof(SafeView), typeof(SafeViewRenderer))]
namespace NeatLibrary.iOS
{
    public class SafeViewRenderer : ViewRenderer<SafeView, UIView>
    {
        public static void Init()
        {
        }

        public SafeViewRenderer()
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<SafeView> e)
        {
            base.OnElementChanged(e);

            var view = new UIView();
            Element.NativeView = view;
            this.SetNativeControl(view);

        }
        protected override void OnElementPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (   e.PropertyName == "X" 
                || e.PropertyName == "Y"
                || e.PropertyName == "Width"
                || e.PropertyName == "Height"
               )
            {
                Control.Frame = new CoreGraphics.CGRect(Element.X,Element.Y,Element.Width, Element.Height);
             }
            if(e.PropertyName == "IsVisible")
            {
                Control.Hidden = !Element.IsVisible;
            }
            if(e.PropertyName == "Renderer")
            {
                Control.Hidden = false;
                Control.BackgroundColor = Element.BackgroundColor.ToUIColor();
            }
            if(e.PropertyName == "BackgroundColor")
            {
                Control.BackgroundColor = Element.BackgroundColor.ToUIColor();
            }

        }
    }
}
