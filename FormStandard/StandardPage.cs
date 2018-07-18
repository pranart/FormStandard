using System;

using Xamarin.Forms;

namespace FormStandard
{
    public class StandardPage : FormTest.Page
	{
		public StandardPage ()
		{
			BackgroundColor = Color.Blue;
			NavigationPage.SetHasNavigationBar (this,false);
		}
	}
}


