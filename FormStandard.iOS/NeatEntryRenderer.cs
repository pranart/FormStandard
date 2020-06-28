using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using UIKit;
using CoreText;

using FormStandard;
using FormStandard.iOS;
using Xamarin.Forms.Internals;
using Foundation;
using System;

[assembly: ExportRenderer (typeof (StandardEntry), typeof (StandardEntryRenderer))]
namespace FormStandard.iOS
{
    [Xamarin.Forms.Internals.Preserve]
	public class StandardEntryRenderer : EntryRenderer
	{
		public StandardEntryRenderer ()
		{
		}
        static public void Initialize()
		{
			
		}
		protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Entry> e)

		{
			base.OnElementChanged(e);
            Recreate();

        }
		void Recreate()
		{
			if (this.Control == null) return;
			//Control.SetPadding (0,0,0,0);
			try
			{
				var element = (Element as StandardEntry);
				try
				{
                    Control.Font = UIFont.SystemFontOfSize((nfloat)element.FontSize * 1.0f);
				}
                catch
                {
				}
				//Control.BorderStyle = UITextBorderStyle.None;
                if (element.HasFrame)
                {
                    this.Control.Layer.BorderColor = UIColor.LightGray.CGColor;
					this.Control.BorderStyle = UITextBorderStyle.RoundedRect;
                }
                else
                {
                    Control.Layer.BorderColor = Color.Transparent.ToCGColor();
					Control.BorderStyle = UITextBorderStyle.None;
                }

				Control.TextColor = element.TextColor.ToUIColor();
				var placeholder = element.Placeholder ?? string.Empty;
				var placeholderColor = element.PlaceholderColor;
				var s = new NSMutableAttributedString(placeholder);
				s.AddAttribute(UIStringAttributeKey.ForegroundColor
					, placeholderColor.ToUIColor(),
					new NSRange(0, placeholder.Length));
				Control.AttributedPlaceholder = s;

			}
			catch(Exception exc)
			{

			}

		}
		protected override void OnElementPropertyChanged (object sender, System.ComponentModel.PropertyChangedEventArgs e)
		{
			var element = (Element as StandardEntry);
			switch (e.PropertyName)
            {
				case "HasFrame":
				case "Placeholder":
				case "PlaceholderColor":
				case "TextSize":
				case "TextColor":
					Recreate();
					break;
            }
			base.OnElementPropertyChanged(sender, e);
		}


	}
}

