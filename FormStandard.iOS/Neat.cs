using System;
using NeatLibrary;
using Xamarin.Forms;


namespace NeatLibrary.iOS
{
	public class Neat 
	{
		public static void Initialize()
		{
			NeatEntryRenderer.Initialize();
			NeatWebViewRenderer.Initialize();
			NeatListViewRenderer.Initialize();
			NeatViewCellRenderer.Initialize();
            HybridWebViewRenderer.Initialize();
			FacebookLoginPageRenderer.Initialize();
			InstagramLoginPageRenderer.Initialize();
			NeatDate.Init();
            SafeViewRenderer.Init();

		}
	}
}
