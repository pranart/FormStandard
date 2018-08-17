using System;
using UIKit;
using FormStandard;
using Xamarin.Forms.Platform.iOS;
using FormStandard.iOS;
using Xamarin.Forms;
using CoreGraphics;

[assembly: ExportRenderer(typeof(StandardSafeView), typeof(StandardSafeViewRenderer))]
namespace FormStandard.iOS
{
    public class StandardSafeViewRenderer : ViewRenderer<StandardSafeView, UIView>
    {
        public static void Init()
        {
        }

        public StandardSafeViewRenderer()
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<StandardSafeView> e)
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
