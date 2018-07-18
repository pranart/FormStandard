using Xamarin.Forms;
using FormStandard;
using FormStandard.Droid;
using Xamarin.Forms.Platform.Android;
using Android.Widget;
using Android.Util;
using Android.Graphics;
using System;

[assembly: ExportRenderer(typeof(StandardLabel), typeof(StandardLabelRenderer))]
namespace FormStandard.Droid
{
    public class StandardLabelRenderer : LabelRenderer {
		protected override void OnElementChanged (ElementChangedEventArgs<Label> e) {
			base.OnElementChanged(e);
			Recreate ();
		}
		private void Recreate()
		{
			StandardLabel customLabel = Element as StandardLabel;
			Recreate (customLabel.FontSize);
		}
		private void Recreate (double fontSize)
		{
			TextView label = (TextView)Control; 
			try
			{
                if(!string.IsNullOrEmpty(Element?.StyleId))
                {
                    Typeface font = Typeface.CreateFromAsset(Forms.Context.Assets, Element?.StyleId+".ttf");
                    label.Typeface = font;
                }

             }
            catch(System.Exception exc)
            {
                System.Diagnostics.Debug.WriteLine(exc.ToString());
			}
			//if (customLabel.Text != null)
			//{
			//	if (customLabel.Text.Length > customLabel.LineLimit - 2)
			//	{
			//		customLabel.Text = customLabel.Text.Substring (0, customLabel.LineLimit - 2) + "..";
			//	}
			//}
			label.SetTextSize (ComplexUnitType.Dip,(float)fontSize);
		}

		protected override void OnElementPropertyChanged (object sender, System.ComponentModel.PropertyChangedEventArgs e)
		{
			base.OnElementPropertyChanged (sender, e);


			if (e.PropertyName == "FontSize" || e.PropertyName == "Text" || e.PropertyName=="LineLimit"
               || e.PropertyName == "IsBold") 
			{
				Recreate ();
				this.Invalidate ();
			}
		}
	}
}
