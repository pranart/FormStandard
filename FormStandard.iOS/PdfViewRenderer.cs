using System;
using Xamarin.Forms.Platform.iOS;
using UIKit;
using FormStandard;
using FormStandard.IOS;
using Xamarin.Forms;
using Foundation;

[assembly:ExportRendererAttribute(typeof(StandardPdfView),typeof(StandardPdfViewRenderer))]
namespace FormStandard.IOS
{
    public class StandardPdfViewRenderer : ViewRenderer<StandardPdfView,UIWebView>
	{
        public StandardPdfViewRenderer ()
		{
		}

		static public void Initialize() { }

        protected override void OnElementChanged (ElementChangedEventArgs<StandardPdfView> e)
		{
			base.OnElementChanged (e);

			var uiWebView = new UIWebView ();
			uiWebView.ScalesPageToFit = true;
			uiWebView.UserInteractionEnabled = true;
			SetNativeControl (uiWebView);

		}

		protected override void OnElementPropertyChanged (object sender, System.ComponentModel.PropertyChangedEventArgs e)
		{
			base.OnElementPropertyChanged (sender, e);
		
			if (e.PropertyName == "Source")
			{
				Control.LoadRequest (new NSUrlRequest (NSUrl.FromString (Element.Path)));
			}

		}
	}
}

