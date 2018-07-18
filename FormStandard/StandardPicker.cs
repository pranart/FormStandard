using System;
using Xamarin.Forms;

namespace FormStandard
{
    public class StandardPicker : FormTest.Picker
	{
		public StandardPicker()
		{
			VerticalOptions = LayoutOptions.Fill;
			HorizontalOptions = LayoutOptions.Fill;
			this.SelectedIndexChanged += Handle_SelectedIndexChanged;

            if (Device.RuntimePlatform == Device.Android)
			{
				Opacity = 0;
			}
		}

		public static readonly BindableProperty SelectedIndexChangedCommandProperty =
			BindableProperty.Create(nameof(SelectedIndexChangedCommandProperty), typeof(Command), typeof(StandardPicker), new Command(() => { }), BindingMode.Default);
		public Command SelectedIndexChangedCommand
		{
			get { return (Command)GetValue(SelectedIndexChangedCommandProperty); }
			set { SetValue(SelectedIndexChangedCommandProperty, value); }
		}

		void Handle_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (SelectedIndexChangedCommand.CanExecute(this.SelectedItem))
			{
				SelectedIndexChangedCommand.Execute(this.SelectedItem);
			}
		}
	}
}

