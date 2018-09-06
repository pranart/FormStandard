using System;
using Xamarin.Forms;
using System.Diagnostics;


namespace FormStandard
{
	public class StandardButton : OnceButton
	{
		public StandardButton ()
		{
			//this.BackgroundColor = Color.Blue;
            this.BorderColor = Color.Transparent;
            this.BorderWidth = 0;


            if (Device.RuntimePlatform == Device.iOS)
            {
                BackgroundColor = Color.Transparent;
            }
            else
            {
                Opacity = 0;
            }


        }
	}
}

