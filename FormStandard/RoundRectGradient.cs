using System;
using NControl.Abstractions;
using NGraphics;
using Xamarin.Forms;

namespace FormStandard
{
	public class RoundRectGradient : NControlView
	{
		public RoundRectGradient()
		{
			VerticalOptions = LayoutOptions.Fill;
			HorizontalOptions = LayoutOptions.Fill;
			this.OnTouchesBegan += Handle_OnTouchesBegan;
			this.OnTouchesEnded += Handle_OnTouchesEnded;
			this.OnTouchesCancelled += Handle_OnTouchesCancelled;
			this.OnTouchesMoved += Handle_OnTouchesMoved;

		}

		public static readonly BindableProperty OnTouchesBeganCommandProperty =
			BindableProperty.Create(nameof(OnTouchesBeganCommandProperty), typeof(Command), typeof(RoundRectGradient), new Command(() => { }), BindingMode.Default);
		public Command OnTouchesBeganCommand
		{
			get { return (Command)GetValue(OnTouchesBeganCommandProperty); }
			set { SetValue(OnTouchesBeganCommandProperty, value); }
		}

		void Handle_OnTouchesBegan(object sender, System.Collections.Generic.IEnumerable<NGraphics.Point> e)
		{
			if (OnTouchesBeganCommand.CanExecute(e))
			{
				OnTouchesBeganCommand.Execute(e);
			}
		}

		public static readonly BindableProperty OnTouchesEndedCommandProperty =
			BindableProperty.Create(nameof(OnTouchesEndedCommandProperty), typeof(Command), typeof(RoundRectGradient), new Command(() => { }), BindingMode.Default);
		public Command OnTouchesEndedCommand
		{
			get { return (Command)GetValue(OnTouchesEndedCommandProperty); }
			set { SetValue(OnTouchesEndedCommandProperty, value); }
		}

		void Handle_OnTouchesEnded(object sender, System.Collections.Generic.IEnumerable<NGraphics.Point> e)
		{
			if (OnTouchesEndedCommand.CanExecute(e))
			{
				OnTouchesEndedCommand.Execute(e);
			}
		}

		public static readonly BindableProperty OnTouchesCancelledCommandProperty =
			BindableProperty.Create(nameof(OnTouchesCancelledCommandProperty), typeof(Command), typeof(RoundRectGradient), new Command(() => { }), BindingMode.Default);
		public Command OnTouchesCancelledCommand
		{
			get { return (Command)GetValue(OnTouchesCancelledCommandProperty); }
			set { SetValue(OnTouchesCancelledCommandProperty, value); }
		}

		void Handle_OnTouchesCancelled(object sender, System.Collections.Generic.IEnumerable<NGraphics.Point> e)
		{
			if (OnTouchesCancelledCommand.CanExecute(e))
			{
				OnTouchesCancelledCommand.Execute(e);
			}
		}

		public static readonly BindableProperty OnTouchesMovedCommandProperty =
			BindableProperty.Create(nameof(OnTouchesMovedCommandProperty), typeof(Command), typeof(RoundRectGradient), new Command(() => { }), BindingMode.Default);
		public Command OnTouchesMovedCommand
		{
			get { return (Command)GetValue(OnTouchesMovedCommandProperty); }
			set { SetValue(OnTouchesMovedCommandProperty, value); }
		}

		void Handle_OnTouchesMoved(object sender, System.Collections.Generic.IEnumerable<NGraphics.Point> e)
		{
			if (OnTouchesMovedCommand.CanExecute(e))
			{
				OnTouchesMovedCommand.Execute(e);
			}
		}

		public override void Draw(ICanvas canvas, Rect rect)
		{

			base.Draw(canvas, rect);

			NGraphics.Size size;
			if (HasShadow)
			{
				size = new NGraphics.Size(rect.Width, rect.Height - 2);
				DrawRect(true, canvas, new NGraphics.Point(rect.Left, rect.Top + 2), size, //Xamarin.Forms.Color.FromRgba(BorderColor.R, BorderColor.G, BorderColor.B, 50).AddLuminosity(-80).ToCross());
					Xamarin.Forms.Color.FromRgba(128, 128, 128, 40).ToCross(), Xamarin.Forms.Color.FromRgba(128, 128, 128, 40).ToCross());
				DrawRect(true, canvas, new NGraphics.Point(rect.Left, rect.Top + 1), size, //Xamarin.Forms.Color.FromRgba(BorderColor.R, BorderColor.G, BorderColor.B, 50).AddLuminosity(-80).ToCross());
					Xamarin.Forms.Color.FromRgba(128, 128, 128, 40).ToCross(), Xamarin.Forms.Color.FromRgba(128, 128, 128, 40).ToCross());
			}
			else
			{
				size = rect.Size;
			}
			DrawRect(false, canvas, rect.TopLeft, size, this.Color.ToCross(), this.ColorGradient.ToCross());

			Thickness ifDouble;
			if (Device.Idiom == TargetIdiom.Tablet)
			{
				ifDouble = new Thickness(Margin.Left * 2, Margin.Top * 2, Margin.Right * 2, Margin.Bottom * 2);
			}
			else
			{
				ifDouble = Margin;
			}

			//LayoutChildren(rect.Left + ifDouble.Left, rect.Top + ifDouble.Top, 
			//               rect.Width/2-(ifDouble.Left+ifDouble.Right), 
			//               rect.Height/2-(ifDouble.Top+ifDouble.Bottom));
		}

		void DrawRect(bool IsShadow, ICanvas canvas, NGraphics.Point point, NGraphics.Size size, NGraphics.Color color, NGraphics.Color colorGradient)
		{
			Pen pen = IsShadow ? new Pen(color, 0) : new Pen(BorderColor.ToCross(), BorderWidth);
			Brush brush = new LinearGradientBrush(new NGraphics.Point(0, 0), new NGraphics.Point(0, 1), color, colorGradient);
			//Brush brush = new SolidBrush(color);
			double flexRadius;
            if (Device.RuntimePlatform == Device.iOS)
			{
				flexRadius = Radius * .50;
			}
			else
			{
				flexRadius = Radius;
			}

			canvas.DrawRectangle(new Rect(point, size), new NGraphics.Size(flexRadius, flexRadius), pen, brush);

		}
		public static readonly BindableProperty HasShadowProperty =
			BindableProperty.Create(nameof(HasShadowProperty), typeof(bool), typeof(RoundRect), false, BindingMode.TwoWay);
		public bool HasShadow
		{
			get { return (bool)GetValue(HasShadowProperty); }
			set { SetValue(HasShadowProperty, value); }
		}

		public static readonly BindableProperty BorderColorProperty =
			BindableProperty.Create(nameof(BorderColorProperty), typeof(Xamarin.Forms.Color), typeof(RoundRect), Xamarin.Forms.Color.Transparent, BindingMode.TwoWay);
		public Xamarin.Forms.Color BorderColor
		{
			get { return (Xamarin.Forms.Color)GetValue(BorderColorProperty); }
			set { SetValue(BorderColorProperty, value); }
		}

		public static readonly BindableProperty BorderWidthProperty =
		BindableProperty.Create(nameof(BorderWidthProperty), typeof(double), typeof(RoundRect), 0.0, BindingMode.TwoWay);
		public double BorderWidth
		{
			get { return (double)GetValue(BorderWidthProperty); }
			set { SetValue(BorderWidthProperty, value); }
		}

		public static readonly BindableProperty ColorProperty =
			BindableProperty.Create(nameof(ColorProperty), typeof(Xamarin.Forms.Color), typeof(RoundRect), Xamarin.Forms.Color.White, BindingMode.TwoWay);
		public Xamarin.Forms.Color Color
		{
			get { return (Xamarin.Forms.Color)GetValue(ColorProperty); }
			set { SetValue(ColorProperty, value); }
		}

		public static readonly BindableProperty ColorGradientProperty =
			BindableProperty.Create(nameof(ColorGradientProperty), typeof(Xamarin.Forms.Color), typeof(RoundRect), Xamarin.Forms.Color.White, BindingMode.TwoWay);
		public Xamarin.Forms.Color ColorGradient
		{
			get { return (Xamarin.Forms.Color)GetValue(ColorGradientProperty); }
			set { SetValue(ColorGradientProperty, value); }
		}

		public static readonly BindableProperty RadiusProperty =
			BindableProperty.Create(nameof(RadiusProperty), typeof(double), typeof(RoundRect), 0.0
									, BindingMode.TwoWay, null);
		public double Radius
		{
			get { return (double)GetValue(RadiusProperty); }
			set { SetValue(RadiusProperty, value); }
		}

		//public static BindableProperty HasShadowProperty =
		//	BindableProperty.Create(nameof(HasShadow), typeof(bool), typeof(RoundRect), true,
		//		BindingMode.TwoWay, null, (bindable, oldValue, newValue) =>
		//		{
		//			var ctrl = (RoundRect)bindable;
		//			ctrl.HasShadow = (bool)newValue;
		//		});


		//public bool HasShadow
		//{
		//	get { return (bool)GetValue(HasShadowProperty); }
		//	set
		//	{
		//		SetValue(HasShadowProperty, value);
		//	}
		//}

		//public static readonly BindableProperty ColorProperty =
		//	BindableProperty.Create(nameof(Xamarin.Forms.Color), typeof(Xamarin.Forms.Color), typeof(RoundRect), Xamarin.Forms.Color.Black,
		//	BindingMode.TwoWay, null, (bindable, oldValue, newValue) => 
		//{
		//	var ctrl = (RoundRect)bindable;
		//	ctrl.Color = (Xamarin.Forms.Color)newValue;
		//}
		//public static Xamarin.Forms.Color Color
		//{
		//	get { return (Xamarin.Forms.Color)GetValue(ColorProperty); }
		//	set { SetValue(ColorProperty, value); }
		//}

		protected override void OnPropertyChanged(string propertyName = null)
		{

			base.OnPropertyChanged(propertyName);
		}

		//public static BindableProperty CommandParameterProperty =
		//	BindableProperty.Create(nameof(CommandParameter), typeof(object), typeof(ActionButton), null,
		//		BindingMode.TwoWay, null, (bindable, oldValue, newValue) =>
		//		{
		//			var ctrl = (ActionButton)bindable;
		//			ctrl.CommandParameter = newValue;
		//		});

		///// <summary>
		///// Gets or sets the color of the buton.
		///// </summary>
		///// <value>The color of the buton.</value>
		//public object CommandParameter
		//{
		//	get { return GetValue(CommandParameterProperty); }
		//	set
		//	{
		//		SetValue(CommandParameterProperty, value);
		//	}
		//}
	}
}
