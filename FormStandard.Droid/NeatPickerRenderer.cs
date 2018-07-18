using System;
using Xamarin.Forms.Platform.Android;
using FormStandard.Droid;
using Xamarin.Forms;
using FormStandard;
using Android.Views;

[assembly:ExportRenderer(typeof(StandardPicker),typeof(StandardPickerRenderer))]
namespace FormStandard.Droid
{
	public class StandardPickerRenderer : PickerRenderer
	{
		public StandardPickerRenderer ()
		{
		}
		public static void Initialize() { }
		protected override void OnElementChanged (ElementChangedEventArgs<Xamarin.Forms.Picker> e)
		{
			base.OnElementChanged (e);
			Control.Gravity = GravityFlags.CenterHorizontal;
		}
	}
}

