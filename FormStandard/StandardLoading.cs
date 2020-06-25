using System;
using Xamarin.Forms;

namespace FormStandard
{
    public class StandardLoading : ActivityIndicator
	{
		public StandardLoading ()
		{
			IsRunning = true;
			VerticalOptions = LayoutOptions.Center;
			HorizontalOptions = LayoutOptions.Center;

		}
	}
}

