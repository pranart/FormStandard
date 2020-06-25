using System;
using Xamarin.Forms;

namespace FormStandard
{
    public class StandardEditor : Editor
	{
        public static readonly BindableProperty HasFrameProperty =
            BindableProperty.Create(nameof(HasFrameProperty), typeof(bool), typeof(StandardEditor), false, BindingMode.Default);
        public bool HasFrame
        {
            get { return (bool)GetValue(HasFrameProperty); }
            set { SetValue(HasFrameProperty, value); }
        }


		public static readonly BindableProperty CompletedCommandProperty =
			BindableProperty.Create(nameof(CompletedCommandProperty), typeof(Command), typeof(StandardEditor), new Command(() => { }), BindingMode.Default);
		public Command CompletedCommand
		{
			get { return (Command)GetValue(CompletedCommandProperty); }
			set { SetValue(CompletedCommandProperty, value); }
		}

		public static readonly BindableProperty TextChangedCommandProperty =
			BindableProperty.Create(nameof(TextChangedCommandProperty), typeof(Command), typeof(StandardEditor), new Command(() => { }), BindingMode.Default);
		public Command TextChangedCommand
		{
			get { return (Command)GetValue(TextChangedCommandProperty); }
			set { SetValue(TextChangedCommandProperty, value); }
		}

        public static readonly BindableProperty IsBorderErrorVisibleProperty =
            BindableProperty.Create(nameof(IsBorderErrorVisible), typeof(bool), typeof(StandardEntry), false, BindingMode.TwoWay);

        public bool IsBorderErrorVisible
        {
            get { return (bool)GetValue(IsBorderErrorVisibleProperty); }
            set
            {
                SetValue(IsBorderErrorVisibleProperty, value);
            }
        }

        public static readonly BindableProperty BorderErrorColorProperty =
            BindableProperty.Create(nameof(BorderErrorColor), typeof(Xamarin.Forms.Color), typeof(StandardEntry), Xamarin.Forms.Color.Orange, BindingMode.TwoWay);

        public Xamarin.Forms.Color BorderErrorColor
        {
            get { return (Xamarin.Forms.Color)GetValue(BorderErrorColorProperty); }
            set
            {
                SetValue(BorderErrorColorProperty, value);
            }
        }

        public static readonly BindableProperty ErrorTextProperty =
            BindableProperty.Create(nameof(ErrorText), typeof(string), typeof(StandardEntry), string.Empty);

        public string ErrorText
        {
            get { return (string)GetValue(ErrorTextProperty); }
            set
            {
                SetValue(ErrorTextProperty, value);
            }
        }
		public StandardEditor()
		{
			HorizontalOptions = LayoutOptions.Fill;
			VerticalOptions = LayoutOptions.Fill;
			FontSize = Device.GetNamedSize(NamedSize.Medium, this);
			this.Completed += Handle_Completed;
			this.TextChanged += Handle_TextChanged;


		}

		void Handle_Completed(object sender, EventArgs e)
		{
			if (CompletedCommand.CanExecute(e))
			{
				CompletedCommand.Execute(e);
			}
		}

		void Handle_TextChanged(object sender, TextChangedEventArgs e)
		{
			if (TextChangedCommand.CanExecute(e))
			{
				TextChangedCommand.Execute(e);
			}
		}
	}
}

