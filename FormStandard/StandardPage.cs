using System;

using Xamarin.Forms;

namespace FormStandard
{
    public class StandardPage : Page
	{
		public StandardPage ()
		{
			BackgroundColor = Color.Blue;
			NavigationPage.SetHasNavigationBar (this,false);
		}
	}
}


