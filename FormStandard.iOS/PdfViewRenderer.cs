using System;
using Xamarin.Forms.Platform.iOS;
using UIKit;
using NeatLibrary;
using NeatLibrary.IOS;
using Xamarin.Forms;
using Foundation;

[assembly:ExportRendererAttribute(typeof(PdfView),typeof(PdfViewRenderer))]
namespace NeatLibrary.IOS
{
	public class PdfViewRenderer : ViewRenderer<PdfView,UIWebView>
	{
		public PdfViewRenderer ()
		{
		}

		static public void Initialize() { }

		protected override void OnElementChanged (ElementChangedEventArgs<PdfView> e)
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

