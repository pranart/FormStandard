using System;
using FormStandard;
using Xamarin.Forms;


namespace FormStandard.iOS
{
	public class Standard 
	{
		public static void Initialize()
		{
			StandardEntryRenderer.Initialize();
			StandardWebViewRenderer.Initialize();
			StandardListViewRenderer.Initialize();
			StandardViewCellRenderer.Initialize();
            HybridWebViewRenderer.Initialize();
			FacebookLoginPageRenderer.Initialize();
			InstagramLoginPageRenderer.Initialize();
			StandardDate.Init();
            StandardSafeViewRenderer.Init();

		}
	}
}
