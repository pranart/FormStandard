using System;
using Xamarin.Forms;


namespace FormStandard
{
    public class StandardScrollView : ScrollView
	{
		public StandardScrollView()
		{
			VerticalOptions = LayoutOptions.Fill;
			HorizontalOptions = LayoutOptions.Fill;
			this.Scrolled += Handle_Scrolled;
		}

		public static readonly BindableProperty ScrolledCommandProperty =
			BindableProperty.Create(nameof(ScrolledCommandProperty), typeof(Command), typeof(StandardScrollView), new Command(() => { }), BindingMode.Default);
		public Command ScrolledCommand
		{
			get { return (Command)GetValue(ScrolledCommandProperty); }
			set { SetValue(ScrolledCommandProperty, value); }
		}

		void Handle_Scrolled(object sender, ScrolledEventArgs e)
		{
			if (ScrolledCommand.CanExecute(e))
			{
				ScrolledCommand.Execute(e);
			}
		}
	}
}

