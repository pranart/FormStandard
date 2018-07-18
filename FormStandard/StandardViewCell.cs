using System;
using Xamarin.Forms;

namespace FormStandard
{
	public class StandardViewCell : ViewCell
	{
		public static readonly BindableProperty SelectedBackgroundColorProperty =
        BindableProperty.Create("SelectedBackgroundColor",
                                typeof(Color),
                                typeof(StandardViewCell),
			                    Xamarin.Forms.Color.Accent);

        public Color SelectedBackgroundColor
        {
            get { return (Color)GetValue(SelectedBackgroundColorProperty); }
            set { SetValue(SelectedBackgroundColorProperty, value); }
        }
	}
}

 