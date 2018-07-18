using System;
using Xamarin.Forms.Platform.iOS;
using Xamarin.Forms;
using UIKit;
using NeatLibrary;
using NeatLibrary.iOS;
using Xamarin.Forms.Internals;

[assembly:ExportRenderer(typeof(NeatWebView),typeof(NeatWebViewRenderer))]
namespace NeatLibrary.iOS
{
    [Preserve]
	public class NeatWebViewRenderer : WebViewRenderer
	{
		public NeatWebViewRenderer ()
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

