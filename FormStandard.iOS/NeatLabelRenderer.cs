using System;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using UIKit;

using System.Diagnostics;
using FormStandard;
using FormStandard.iOS;
using Xamarin.Forms.Internals;

[assembly: ExportRenderer (typeof (StandardLabel), typeof (StandardLabelRenderer))]
namespace FormStandard.iOS
{
    [Preserve]
	public class StandardLabelRenderer : LabelRenderer {

		static public void Initialize() 
		{ 
		}
		protected override void OnElementChanged (ElementChangedEventArgs<Label> e) {
			base.OnElementChanged (e);
			Recreate ();
		}
		private void Recreate()
		{
			StandardLabel customLabel = Element as StandardLabel;
			if (customLabel == null) return;

			try
			{
				Recreate (customLabel.FontSize);
			}catch{
			}
		}
		private void Recreate (double fontSize)
		{
			StandardLabel element = Element as StandardLabel;
			if (element == null ) return;

			UILabel label = Control as UILabel;
            
			//string typeface = customLabel.CustomTypeFace;
			nfloat size = (nfloat)fontSize;
			if (element.FontAttributes.HasFlag(FontAttributes.Bold))
			{
				Control.Font = UIFont.FromName("Kanit-Bold", (nfloat)element.FontSize);

			}
			else
			{
				Control.Font = UIFont.FromName("Kanit-Regular", (nfloat)element.FontSize);

			}

			if (element.Text == null)
				return;
			string text = element.Text;
			if (element.Text.Length > element.LineLimit-1)
			{
				string str = text.Substring (0, element.LineLimit-1) + "ฯ";
				if (str.Substring (0, 1) == "\"") {
					str = str + "\"";
				}
				text = str;
			}
//			if (customLabel.IsUnderline) {
//				var textUnderline = new NSMutableAttributedString (text);
//				textUnderline.AddAttribute (UIStringAttributeKey.UnderlineStyle, NSNumber.FromNInt (1), new NSRange (0, textUnderline.Length));
//				label.AttributedText = textUnderline;
//			} else {
//				var textUnderline = new NSMutableAttributedString (text);
//				label.AttributedText = textUnderline;
//			}

		}

		protected override void OnElementPropertyChanged (object sender, System.ComponentModel.PropertyChangedEventArgs e)
		{
			base.OnElementPropertyChanged (sender, e);

			if (e.PropertyName == "IsUnderline") 
			{
				Recreate ();
				this.SetNeedsDisplay ();
			}
			if (e.PropertyName == "CustomTypeFace") 
			{
				Recreate ();
				this.SetNeedsDisplay ();
			}
			if (e.PropertyName == "FontSize" || e.PropertyName == "Text" || e.PropertyName=="LineLimit") 
			{
				Recreate ();
				this.SetNeedsDisplay ();
			}
		}

	}
}

