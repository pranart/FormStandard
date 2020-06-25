using System;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using FormStandard;
using FormStandard.Droid;
using Android.Webkit;
using Java.Interop;
using Android.OS;

[assembly: ExportRenderer(typeof(HybridWebView), typeof(HybridWebViewRenderer))]
namespace FormStandard.Droid
{
	public class HybridWebViewRenderer : ViewRenderer<HybridWebView, Android.Webkit.WebView>
	{
		const string JavaScriptFunction = "function invokeCSharpAction(){jsBridge.invokeAction('');}";

		static public void Initialize() { }

		protected override void OnElementChanged(ElementChangedEventArgs<HybridWebView> e)
		{
			base.OnElementChanged(e);

			if (Control == null)
			{
				bool isMainThread = Looper.MyLooper()==Looper.MainLooper;

				var webView = new Android.Webkit.WebView(Forms.Context);
				webView.Settings.JavaScriptEnabled = true;
				SetNativeControl(webView);
			}
			if (e.OldElement != null)
			{
				Control.RemoveJavascriptInterface("jsBridge");
				var hybridWebView = e.OldElement as HybridWebView;
				hybridWebView.Cleanup();
			}
			if (e.NewElement != null)
			{
				
				Control.AddJavascriptInterface(new JSBridge(this), "jsBridge");
				Control.LoadUrl(string.Format("file:///android_asset/{0}", Element.Uri));
				InjectJS(JavaScriptFunction);
			}
		}

		void InjectJS(string script)
		{
			if (Control != null)
			{
				Control.LoadUrl(string.Format("javascript: {0}", script));
			}
		}
	}
	public class JSBridge : Java.Lang.Object
	{
		readonly WeakReference<HybridWebViewRenderer> hybridWebViewRenderer;

		public JSBridge(HybridWebViewRenderer hybridRenderer)
		{
			hybridWebViewRenderer = new WeakReference<HybridWebViewRenderer>(hybridRenderer);
		}

		[JavascriptInterface]
		//[Export("invokeAction")]
		public void InvokeAction(string data)
		{
			HybridWebViewRenderer hybridRenderer;

			bool isMainThread = (Looper.MyLooper() == Looper.MainLooper);
			Device.BeginInvokeOnMainThread(() =>
			{
				if (hybridWebViewRenderer != null && hybridWebViewRenderer.TryGetTarget(out hybridRenderer))
				{
					hybridRenderer.Element.InvokeAction(data);
				}
			});
		}
	}
}
