using System;
using Xamarin.Forms;

namespace FormStandard
{
    public class StandardLoading : FormTest.ActivityIndicator
	{
		public StandardLoading ()
		{
			IsRunning = true;
			VerticalOptions = LayoutOptions.Center;
			HorizontalOptions = LayoutOptions.Center;

		}
	}
}

