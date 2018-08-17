using System;
using Xamarin.Forms.Platform.iOS;
using Xamarin.Forms;
using UIKit;
using FormStandard;
using FormStandard.iOS;
using Xamarin.Forms.Internals;

[assembly:ExportRenderer(typeof(StandardWebView),typeof(StandardWebViewRenderer))]
namespace FormStandard.iOS
{
    [Preserve]
	public class StandardWebViewRenderer : WebViewRenderer
	{
		public StandardWebViewRenderer ()
		{
		}
		static public void Initialize() { }

		protected override void OnElementChanged (VisualElementChangedEventArgs e)
		{
			base.OnElementChanged (e);

			UIWebView webView = NativeView as UIWebView;
			if (webView != null)
			{
				webView.ScrollView.ViewForZoomingInScrollView = null;
			
			}
		}
	}
		
}

