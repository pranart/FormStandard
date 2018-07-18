using System;
using Xamarin.Forms;
using System.Diagnostics;


namespace FormStandard
{
	public class StandardButton : FormTest.Button
	{
		public StandardButton ()
		{
			this.VerticalOptions = LayoutOptions.Fill;
			this.HorizontalOptions = LayoutOptions.Fill;
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

			Clicked += StandardButton_Clicked;

        }
        public object Tag { get; set; }
		public event EventHandler ClickOnce;
		public static DateTime LastClickTime { get; set; } = DateTime.MinValue;
		void StandardButton_Clicked(object sender, System.EventArgs e)
		{
            if ((DateTime.Now - LastClickTime).Milliseconds > 100 ) 
			{
				ClickOnce?.Invoke(this, null);
				LastClickTime = DateTime.Now;
			}
		}
	}
}

