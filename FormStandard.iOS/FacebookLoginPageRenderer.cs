using System;
using Xamarin.Auth;
using Xamarin.Forms.Platform.iOS;
using Xamarin.Forms;
using NeatLibrary;
using NeatLibrary.iOS;


[assembly: ExportRenderer (typeof (FacebookLoginPage), typeof (FacebookLoginPageRenderer))]

namespace NeatLibrary.iOS
{
	public class FacebookLoginPageRenderer : PageRenderer
	{

		bool IsShown;

        static public void Initialize () {}
		public override void ViewDidAppear (bool animated)
		{
			base.ViewDidAppear (animated);

			// Fixed the issue that on iOS 8, the modal wouldn't be popped.
			// url : http://stackoverflow.com/questions/24105390/how-to-login-to-facebook-in-xamarin-forms
			if(	! IsShown ) {

				IsShown = true;

				var auth = new OAuth2Authenticator (
                    clientId: OAuthSettings.Instance.ClientId, // your OAuth2 client id
					scope: OAuthSettings.Instance.Scope, // The scopes for the particular API you're accessing. The format for this will vary by API.
					authorizeUrl: new Uri (OAuthSettings.Instance.AuthorizeUrl), // the auth URL for the service
					redirectUrl: new Uri (OAuthSettings.Instance.RedirectUrl)); // the redirect URL for the service




				auth.Completed += (sender, eventArgs) => {
					// We presented the UI, so it's up to us to dimiss it on iOS.
					OAuthSettings.Instance.SuccessfulLoginAction.Invoke();

					if (eventArgs.IsAuthenticated) {
						// Use eventArgs.Account to do wonderful things
						OAuthSettings.Instance.SaveToken(eventArgs.Account.Properties["access_token"]);
					} else {
						// The user cancelled
					}
				};

				PresentViewController (auth.GetUI (), true, null);

			}

		}
	}
}

