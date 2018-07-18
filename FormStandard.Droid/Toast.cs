using System;
using FormStandard;
using Xamarin.Forms;
using Android.Widget;

[assembly:Dependency(typeof(FormStandard.Droid.Toast))]
namespace FormStandard.Droid
{
    public class Toast : IToast
    {
        public Toast()
        {
        }

        void IToast.Toast(string message)
        {
            if (string.IsNullOrWhiteSpace(message)) throw new ArgumentException("string.IsNullOrWhiteSpace(message)");
            Android.Widget.Toast.MakeText(Forms.Context,message,ToastLength.Long).Show();
        }
    }
}
