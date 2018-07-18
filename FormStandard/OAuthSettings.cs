using System;
using Xamarin.Forms;

namespace FormStandard
{
	public class OAuthSettings
	{
        static public OAuthSettings Instance { get; set; }

		public OAuthSettings(
			string clientId,
			string scope,
			string authorizeUrl,
			string redirectUrl)
		{
			ClientId = clientId;
			Scope = scope;
			AuthorizeUrl = authorizeUrl;
			RedirectUrl = redirectUrl;
		}

		public string ClientId {get; private set;}
		public string Scope {get; private set;}
		public string AuthorizeUrl {get; private set;}
		public string RedirectUrl {get; private set;}
		public INavigation INavigation { get; set; }
        public Action SuccessfulLoginAction
        {
            get
            {
                return () => { INavigation.PopModalAsync(false); };
            }
        }
        public Action AfterLoginAction { get; set; }
        string _Token = null;
        public string Token
        {
            get { return _Token; }
        }

        public void SaveToken(string token)
        {
            _Token = token;

            AfterLoginAction?.Invoke();
            // broadcast a message that authentication was successful
            //MessagingCenter.Send<object>(this, "FacebookLoginSuccess");
        }

        public bool IsAuthenticated
        {
            get { return !string.IsNullOrWhiteSpace(_Token); }
        }


	}
}

