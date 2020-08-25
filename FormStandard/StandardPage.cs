using System;

using Xamarin.Forms;

namespace FormStandard
{
    public class StandardPage : ContentPage
	{
		public StandardPage ()
		{
			BackgroundColor = Constant.White;
			NavigationPage.SetHasNavigationBar (this,false);
		}
	}
}


