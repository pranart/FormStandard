using System;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using FormStandard;
using FormStandard.iOS;
using WebKit;
using System.IO;
using Foundation;
using Reachability;

[assembly: ExportRenderer(typeof(HybridWebView), typeof(HybridWebViewRenderer))]
namespace FormStandard.iOS
{
	public class HybridWebViewRenderer : ViewRenderer<HybridWebView, WKWebView>, IWKScriptMessageHandler
	{
		const string JavaScriptFunction = "function invokeCSharpAction(){window.webkit.messageHandlers.invokeAction.postMessage('');}";
		WKUserContentController userController;

		static public void Initialize() { }

		protected override void OnElementChanged(ElementChangedEventArgs<HybridWebView> e)
		{
			base.OnElementChanged(e);


			if (Control == null)
			{
				userController = new WKUserContentController();
				var script = new WKUserScript(new NSString(JavaScriptFunction), WKUserScriptInjectionTime.AtDocumentEnd, false);
				userController.AddUserScript(script);
				userController.AddScriptMessageHandler(this, "invokeAction");

				var config = new WKWebViewConfiguration { UserContentController = userController };
				var webView = new WKWebView(Frame, config);
				SetNativeControl(webView);
				Reachability.Reachability.ReachabilityChanged += (sender, eReach) =>
				{
					webView.Reload();
				};

			}
			if (e.OldElement != null)
			{
				userController.RemoveAllUserScripts();
				userController.RemoveScriptMessageHandler("invokeAction");
				var hybridWebView = e.OldElement as HybridWebView;
				hybridWebView.Cleanup();
			}
			if (e.NewElement != null)
			{
				string fileName = Path.Combine(NSBundle.MainBundle.BundlePath, string.Format("{0}", Element.Uri));
				Control.LoadRequest(new NSUrlRequest(new NSUrl(fileName, false)));
			}
		}

		public void DidReceiveScriptMessage(WKUserContentController userContentController, WKScriptMessage message)
		{
			Element.InvokeAction("");
		}
	}
}

