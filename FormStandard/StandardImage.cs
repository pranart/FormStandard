using System;
using FFImageLoading.Forms;
using Xamarin.Forms;


namespace FormStandard
{
    public class StandardImage : CachedImage
	{
		public StandardImage()
		{
			VerticalOptions = LayoutOptions.Fill;
			HorizontalOptions = LayoutOptions.Fill;
			var panGesture = new PanGestureRecognizer();
			panGesture.PanUpdated += (s, e) =>
			{
				if(PanCommand.CanExecute(e))
				{
					PanCommand.Execute(e);
				}
			};
			this.GestureRecognizers.Add(panGesture);
		}

		public static readonly BindableProperty PanCommandProperty =
			BindableProperty.Create(nameof(PanCommandProperty), typeof(Command), typeof(StandardImage), new Command(() => { }), BindingMode.Default);
		public Command PanCommand
		{
			get { return (Command)GetValue(PanCommandProperty); }
			set { SetValue(PanCommandProperty, value); }
		}

        public static readonly BindableProperty TagProperty =
            BindableProperty.Create(nameof(TagProperty), typeof(object), typeof(StandardImage), null, BindingMode.Default);
        public object Tag
        {
            get { return (object)GetValue(TagProperty); }
            set { SetValue(TagProperty, value); }
        }
    }
}

