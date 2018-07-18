using System;
using NeatLibrary.iOS;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ResolutionGroupName("NeatLibrary")]
[assembly: ExportEffect(typeof(LastPageEffect), "LastPageEffect")]
namespace NeatLibrary.iOS
{
    public class LastPageEffect : PlatformEffect
    {
        public static UIKit.UIView LastPage { get; set;  }

        protected override void OnAttached()
        {
            try
            {
                LastPage = Control;
            }
            catch (Exception)
            {
                
            }
        }

        protected override void OnDetached()
        {
        }

    }
}
