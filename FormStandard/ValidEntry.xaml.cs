using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace FormStandard
{
    public partial class ValidEntry : ContentView
    {
        public ValidEntry()
        {
            InitializeComponent();
            Entry.TextChanged += (sender, e) =>
            {
                EntryText = e.NewTextValue;
            };

        }

        public StandardEntry Entry
        {
            get
            {
                return PrivateStandardEntry;

            }
        }

        //public static readonly BindableProperty HasFrameProperty =
        //  BindableProperty.Create(nameof(HasFrameProperty), typeof(bool), typeof(StandardEntry), false, BindingMode.Default,null,(bindable, oldValue, newValue) => 
        //{
        //  (bindable as ValidEntry).HasFrame = (bool)newValue;
        //});
        //public bool HasFrame
        //{
        //    get { return (bool)GetValue(HasFrameProperty); }
        //    set { SetValue(HasFrameProperty, value); }
        //}
        public static readonly BindableProperty MaskProperty =
            BindableProperty.Create(nameof(MaskProperty), typeof(string), typeof(ValidEntry), string.Empty, BindingMode.Default, null, (bindable, oldValue, newValue) =>
            {
                (bindable as ValidEntry).MaskBehavior.Mask = (string)newValue;
            });
        public string Mask
        {
            get { return (string)GetValue(MaskProperty); }
            set { SetValue(MaskProperty, value); }
        }

        public static readonly BindableProperty CornerRadiusProperty =
            BindableProperty.Create(nameof(CornerRadiusProperty), typeof(int), typeof(ValidEntry), 5, BindingMode.Default, null, (bindable, oldValue, newValue) =>
            {
                (bindable as ValidEntry).RoundRectObject.CornerRadius = (int)newValue;
            });
        public int CornerRadius
        {
            get { return (int)GetValue(CornerRadiusProperty); }
            set { SetValue(CornerRadiusProperty, value); }
        }

        public static readonly BindableProperty ColorProperty =
            BindableProperty.Create(nameof(ColorProperty), typeof(Color), typeof(ValidEntry), Color.Transparent, BindingMode.Default, null, (bindable, oldValue, newValue) =>
            {
                (bindable as ValidEntry).RoundRectObject.BackgroundColor = (Color)newValue;
            });
        public Color Color
        {
            get { return (Color)GetValue(ColorProperty); }
            set { SetValue(ColorProperty, value); }
        }

        public static readonly BindableProperty FontSizeProperty =
            BindableProperty.Create(nameof(FontSizeProperty), typeof(double), typeof(ValidEntry), 0.0, BindingMode.OneWay, (bindable, value) =>
            {
                ((ValidEntry)bindable).Entry.FontSize = (double)value;
                return true;
            });
        public double FontSize
        {
            get { return (double)GetValue(FontSizeProperty); }
            set { SetValue(FontSizeProperty, value); }
        }

        public static readonly BindableProperty EntryTextProperty =
            BindableProperty.Create(nameof(EntryTextProperty), typeof(string), typeof(ValidEntry), "", BindingMode.TwoWay, (bindable, value) =>
            {
                if (((ValidEntry)bindable).Entry.Text != (string)value)
                {
                    ((ValidEntry)bindable).Entry.Text = (string)value;
                }
                return true;
            });
        public string EntryText
        {
            get { return (string)GetValue(EntryTextProperty); }
            set { SetValue(EntryTextProperty, value); }
        }
        public static readonly BindableProperty PlaceholderProperty =
            BindableProperty.Create(nameof(PlaceholderProperty), typeof(string), typeof(ValidEntry), "", BindingMode.OneWay, (bindable, value) =>
            {
                ((ValidEntry)bindable).Entry.Placeholder = (string)value;
                return true;
            });
        public string Placeholder
        {
            get { return (string)GetValue(PlaceholderProperty); }
            set
            {
                SetValue(PlaceholderProperty, value);
                Entry.Placeholder = value;

            }
        }
        public static readonly BindableProperty IsPasswordProperty =
            BindableProperty.Create(nameof(IsPasswordProperty), typeof(bool), typeof(ValidEntry), false, BindingMode.OneWay, (bindable, value) =>
            {
                ((ValidEntry)bindable).Entry.IsPassword = (bool)value;
                return true;
            });
        public bool IsPassword
        {
            get { return (bool)GetValue(IsPasswordProperty); }
            set
            {
                SetValue(IsPasswordProperty, value);
                Entry.IsPassword = value;

            }
        }

        public static readonly BindableProperty ErrorTextProperty =
            BindableProperty.Create(nameof(ErrorText), typeof(string), typeof(ValidEntry), string.Empty, BindingMode.TwoWay, (bindable, value) =>
            {
                (bindable as ValidEntry).Entry.ErrorText = (string)value;
                return true;
            });

        public string ErrorText
        {
            get { return (string)GetValue(ErrorTextProperty); }
            set
            {
                SetValue(ErrorTextProperty, value);
                Entry.ErrorText = value;
            }
        }

        public static readonly BindableProperty TextColorProperty =
            BindableProperty.Create(nameof(TextColor), typeof(Color), typeof(ValidEntry), Color.Default, BindingMode.TwoWay, (bindable, value) =>
            {
                var validEntry = (bindable as ValidEntry);
                validEntry.Entry.TextColor = (Color)value;
                validEntry.RoundRectObject.BorderColor = (Color)value;


                return true;
            });

        public Color TextColor
        {
            get { return (Color)GetValue(TextColorProperty); }
            set
            {
                SetValue(TextColorProperty, value);

            }
        }

        public static readonly BindableProperty IsBorderErrorVisibleProperty =
            BindableProperty.Create(nameof(IsBorderErrorVisible), typeof(bool), typeof(ValidEntry), false, BindingMode.TwoWay, (bindable, value) =>
            {
                (bindable as ValidEntry).Entry.IsBorderErrorVisible = (bool)value;
                return true;
            });

        public bool IsBorderErrorVisible
        {
            get { return (bool)GetValue(IsBorderErrorVisibleProperty); }
            set
            {
                SetValue(IsBorderErrorVisibleProperty, value);

            }
        }

        public static readonly BindableProperty KeyboardProperty =
            BindableProperty.Create(nameof(Keyboard), typeof(Xamarin.Forms.Keyboard), typeof(ValidEntry), Xamarin.Forms.Keyboard.Default, BindingMode.TwoWay, (bindable, value) =>
            {
                (bindable as ValidEntry).Entry.Keyboard = (Xamarin.Forms.Keyboard)value;
                return true;
            });

        public Xamarin.Forms.Keyboard Keyboard
        {
            get { return (Xamarin.Forms.Keyboard)GetValue(KeyboardProperty); }
            set
            {
                SetValue(KeyboardProperty, value);
            }
        }
    }
}
