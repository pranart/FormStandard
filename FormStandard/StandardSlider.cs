using System;
using Xamarin.Forms;

namespace FormStandard
{
    public class StandardSlider : Slider
	{
		public StandardSlider()
		{
			this.ValueChanged += (sender, e) => 
			{
				if(CommandSlider == null)
				{
					return;
				}
				if(CommandSlider.CanExecute(this))
				{
					CommandSlider.Execute(this);
				}
			};
		}
		public static readonly BindableProperty CommandSliderProperty =
			BindableProperty.Create(nameof(CommandSliderProperty), typeof(Command), typeof(StandardSlider), null, BindingMode.OneWay);

		public Command CommandSlider
		{
			get { return (Command)GetValue(CommandSliderProperty);}
			set { SetValue(CommandSliderProperty, value);}
		}
	}
}
