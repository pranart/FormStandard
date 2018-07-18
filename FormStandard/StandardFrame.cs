using System;
using Xamarin.Forms;

namespace FormStandard
{
    public class StandardFrame : Frame
	{
		public StandardFrame ()
		{
			this.BorderColor = Color.Transparent;
			this.HasShadow = false;

			this.HorizontalOptions = LayoutOptions.Fill;
			this.VerticalOptions = LayoutOptions.Fill;
			this.BackgroundColor = Color.Transparent;
			Padding = new Thickness(5);
		}
	}
}

