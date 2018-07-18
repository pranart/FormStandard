using System;
using Xamarin.Auth;
using Xamarin.Forms.Platform.iOS;
using Xamarin.Forms;
using NeatLibrary;
using NeatLibrary.iOS;

[assembly: ExportRenderer(typeof(InstagramLoginPage), typeof(InstagramLoginPageRenderer))]
namespace NeatLibrary.iOS
{
	public class InstagramLoginPageRenderer : PageRenderer
	{
		bool IsShown;

		static public void Initialize() { }
		public override void ViewDidAppear(bool animated)
		{
			base.ViewDidAppear(animated);
			if (!IsShown)
			{

				IsShown = true;

				var auth = new OAuth2Authenticator(
					clientId: OAuthSettingsInstagram.Instance.ClientId, // your OAuth2 client id
					scope: OAuthSettingsInstagram.Instance.Scope, // The scopes for the particular API you're accessing. The format for this will vary by API.
					authorizeUrl: new Uri(OAuthSettingsInstagram.Instance.AuthorizeUrl), // the auth URL for the service
					redirectUrl: new Uri(OAuthSettingsInstagram.Instance.RedirectUrl)); // the redirect URL for the service

				auth.Completed += (sender, eventArgs) =>
				{
					// We presented the UI, so it's up to us to dimiss it on iOS.
					OAuthSettingsInstagram.Instance.SuccessfulLoginAction.Invoke();

					if (eventArgs.IsAuthenticated)
					{
						// Use eventArgs.Account to do wonderful things
						OAuthSettingsInstagram.Instance.SaveToken(eventArgs.Account.Properties["access_token"]);
					}
					else
					{
						// The user cancelled
					}
				};
				PresentViewController(auth.GetUI(), true, null);
			}
		}
	}
}
