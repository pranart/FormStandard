using System;
namespace FormStandard
{
    using System;
    using Xamarin.Forms;

    namespace FormStandard
    {
        public class EmptyEditorValidatorBehavior : Behavior<StandardEditor>
        {
            StandardEditor control;

            protected override void OnAttachedTo(StandardEditor bindable)
            {
                bindable.TextChanged += HandleTextChanged;
                bindable.PropertyChanged += OnPropertyChanged;
                control = bindable;
                //_placeHolder = bindable.Placeholder;
                //_placeHolderColor = bindable.PlaceholderColor;
            }

            void HandleTextChanged(object sender, TextChangedEventArgs e)
            {
                if (!string.IsNullOrEmpty(e.NewTextValue))
                {
                    ((StandardEditor)sender).IsBorderErrorVisible = false;
                }
            }

            protected override void OnDetachingFrom(StandardEditor bindable)
            {
                bindable.TextChanged -= HandleTextChanged;
                bindable.PropertyChanged -= OnPropertyChanged;
            }

            void OnPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
            {
                if (e.PropertyName == StandardEditor.IsBorderErrorVisibleProperty.PropertyName && control != null)
                {
                    if (control.IsBorderErrorVisible)
                    {
                        //control.Placeholder = control.ErrorText;
                        //control.PlaceholderColor = control.BorderErrorColor;
                        control.Text = string.Empty;
                    }

                    else
                    {
                        //control.Placeholder = _placeHolder;
                        //control.PlaceholderColor = _placeHolderColor;
                    }

                }
            }
        }
    }
}
