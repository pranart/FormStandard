using Xamarin.Forms.Platform.Android;
using Xamarin.Forms;
using FormStandard;

[assembly:ExportRenderer(typeof(StandardWebView),typeof(FormStandard.Droid.StandardWebViewRenderer))]
namespace FormStandard.Droid
{
	public class StandardWebViewRenderer : WebViewRenderer
	{
		public StandardWebViewRenderer ()
		{
		}
		public static void Initialize() { }
		protected override void OnElementChanged (ElementChangedEventArgs<WebView> e)
		{
			base.OnElementChanged(e);

			if (Control != null)
			{

				Control.Settings.BuiltInZoomControls = true;
				Control.Settings.DisplayZoomControls = true;
			}

		}
	}
}

