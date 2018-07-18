using System; 
using Android.App;
using Xamarin.Auth;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using FormStandard;
using FormStandard.Droid;
using System.Diagnostics;

[assembly: ExportRenderer (typeof (FacebookLoginPage), typeof (FacebookLoginPageRenderer))]

namespace FormStandard.Droid
{
	public class FacebookLoginPageRenderer : PageRenderer
	{
        static public void Initialize(){}

        protected override void OnElementChanged(ElementChangedEventArgs<Page> e)
        {
            base.OnElementChanged(e);

            // this is a ViewGroup - so should be able to load an AXML file and FindView<>
            var activity = this.Context as Activity;

            OAuth2Authenticator auth;
            try
            {
                auth = new OAuth2Authenticator (
                    clientId: OAuthSettings.Instance.ClientId, // your OAuth2 client id
                    scope: OAuthSettings.Instance.Scope, // The scopes for the particular API you're accessing. The format for this will vary by API.
                    authorizeUrl: new Uri (OAuthSettings.Instance.AuthorizeUrl), // the auth URL for the service
                    redirectUrl: new Uri (OAuthSettings.Instance.RedirectUrl)); // the redirect URL for the service
                
            }
            catch(Exception exc)
            {
                System.Diagnostics.Debug.WriteLine(exc.ToString());
                return;
            }
			auth.AllowCancel = false;
            auth.Completed += (sender, eventArgs) => {
                if (eventArgs.IsAuthenticated) {
                    OAuthSettings.Instance.SuccessfulLoginAction.Invoke();
                    // Use eventArgs.Account to do wonderful things
                    string token = eventArgs.Account.Properties["access_token"];
                    OAuthSettings.Instance.SaveToken(token);
                } else {
                    // The user cancelled
                }
            };

			activity.StartActivity (auth.GetUI(activity));
        }
	}
}