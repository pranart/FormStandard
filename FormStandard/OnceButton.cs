using System;
using Xamarin.Forms;

namespace FormStandard
{
    public class OnceButton : Button
    {
        public OnceButton()
        {
            this.VerticalOptions = LayoutOptions.Fill;
            this.HorizontalOptions = LayoutOptions.Fill;
            Clicked += StandardButton_Clicked;
        }
        public object Tag { get; set; }
        public event EventHandler ClickOnce;
        public static DateTime LastClickTime { get; set; } = DateTime.MinValue;
        void StandardButton_Clicked(object sender, System.EventArgs e)
        {
            if ((DateTime.Now - LastClickTime) > TimeSpan.FromSeconds(1.2))
            {
                ClickOnce?.Invoke(this, null);
                LastClickTime = DateTime.Now;
                if(OnceCommand?.CanExecute(CommandParameter) ?? false)
                {
                    OnceCommand?.Execute(CommandParameter);
                }
            }
        }

        public static readonly BindableProperty OnceCommandProperty =
            BindableProperty.Create(nameof(OnceCommandProperty), typeof(Command), typeof(OnceButton), new Command(() => { }), BindingMode.Default);
        public Command OnceCommand
        {
            get { return (Command)GetValue(OnceCommandProperty); }
            set { SetValue(OnceCommandProperty, value); }
        }


    }
}
