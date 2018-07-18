using System;
using Android.App;
using FormStandard;
using FormStandard.Droid;
using Xamarin.Auth;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(InstagramLoginPage), typeof(InstagramLoginPageRenderer))]
namespace FormStandard.Droid
{
	public class InstagramLoginPageRenderer : PageRenderer
	{
		static public void Initialize() { }
		protected override void OnElementChanged(ElementChangedEventArgs<Page> e)
		{
			base.OnElementChanged(e);
			// this is a ViewGroup - so should be able to load an AXML file and FindView<>
			var activity = this.Context as Activity;
			OAuth2Authenticator auth;
			try
			{
				auth = new OAuth2Authenticator(
					clientId: OAuthSettingsInstagram.Instance.ClientId, // your OAuth2 client id
					 scope: OAuthSettingsInstagram.Instance.Scope, // The scopes for the particular API you're accessing. The format for this will vary by API.
					authorizeUrl: new Uri(OAuthSettingsInstagram.Instance.AuthorizeUrl), // the auth URL for the service
					redirectUrl: new Uri(OAuthSettingsInstagram.Instance.RedirectUrl)); // the redirect URL for the service

			}
			catch (Exception exc)
			{
				System.Diagnostics.Debug.WriteLine(exc.ToString());
				return;
			}
			auth.AllowCancel = false;
			auth.Completed += (sender, eventArgs) =>
			{
				if (eventArgs.IsAuthenticated)
				{
					OAuthSettingsInstagram.Instance.SuccessfulLoginAction.Invoke();
					// Use eventArgs.Account to do wonderful things
					string token = eventArgs.Account.Properties["access_token"];
					OAuthSettingsInstagram.Instance.SaveToken(token);
				}
				else
				{
					// The user cancelled
				}
			};
			activity.StartActivity (auth.GetUI(activity));
		}
	}
}
