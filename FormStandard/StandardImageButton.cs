using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace FormStandard
{
    public class StandardImageButton : StandardGrid
    {
        public StandardImage Image { get;  protected set; }
        public StandardButton Button { get; protected set; }

        public StandardImageButton()
        {
            Image = new StandardImage();
            this.Add(Image);
            Button = new StandardButton();
            this.Add(Button);

            Button.Clicked += (sender, e) => 
            {
                Clicked?.Invoke(sender, e);
                if(Command?.CanExecute(sender) ?? false)
                {
                    Command?.Execute(sender);
                }
            };
        }

        public event EventHandler<EventArgs> Clicked;


        public static readonly BindableProperty CommandProperty =
            BindableProperty.Create(nameof(CommandProperty), typeof(Command), typeof(StandardImageButton), new Command(() => { }), BindingMode.Default);
        public Command Command
        {
            get { return (Command)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }

        public ImageSource Source
        {
            get 
            {
                return Image?.Source;
            }
            set 
            {
                Image.Source = value;
            }
        }

        public Aspect Aspect
        {
            get 
            {
                return Image.Aspect;
            }
            set 
            {
                Image.Aspect = value;
            }
        }


    }
}
