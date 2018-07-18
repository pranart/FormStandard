using System;
using Xamarin.Forms;

namespace FormStandard
{
    public class EmptyEntryValidatorBehavior : Behavior<StandardEntry>
    {
        StandardEntry control;
        string _placeHolder;
        Xamarin.Forms.Color _placeHolderColor;

        protected override void OnAttachedTo(StandardEntry bindable)
        {
            bindable.TextChanged += HandleTextChanged;
            bindable.PropertyChanged += OnPropertyChanged;
            control = bindable;
            _placeHolder = bindable.Placeholder;
            _placeHolderColor = bindable.PlaceholderColor;
        }

        void HandleTextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(e.NewTextValue))
            {
                ((StandardEntry)sender).IsBorderErrorVisible = false;
            }
        }

        protected override void OnDetachingFrom(StandardEntry bindable)
        {
            bindable.TextChanged -= HandleTextChanged;
            bindable.PropertyChanged -= OnPropertyChanged;
        }

        void OnPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == StandardEntry.IsBorderErrorVisibleProperty.PropertyName && control != null)
            {
                if (control.IsBorderErrorVisible)
                {
                    control.Placeholder = control.ErrorText;
                    control.PlaceholderColor = control.BorderErrorColor;
                    control.Text = string.Empty;
                }

                else
                {
                    control.Placeholder = _placeHolder;
                    control.PlaceholderColor = _placeHolderColor;
                }

            }
        }
    }
}
