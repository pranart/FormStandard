using System;
using FormStandard.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly:ResolutionGroupName ("FormStandard")]
[assembly:ExportEffect (typeof(LastPageEffect), "LastPageEffect")]
namespace FormStandard.Droid
{
    public class LastPageEffect : PlatformEffect
    {
        public static Android.Views.View LastPage { get; set; }
        protected override void OnAttached()
        {
            try
            {
                LastPage = Control;

            }
            catch (Exception ex)
            {
                Console.WriteLine("Cannot set property on attached control. Error: ", ex.Message);
            }
        }

        protected override void OnDetached()
        {
        }

        protected override void OnElementPropertyChanged(System.ComponentModel.PropertyChangedEventArgs args)
        {
            base.OnElementPropertyChanged(args);
            LastPage = Control;
        }
    }
}
