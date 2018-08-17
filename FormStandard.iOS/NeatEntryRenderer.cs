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

		}
		void Recreate()
		{
			if (this.Control == null) return;
			//Control.SetPadding (0,0,0,0);
			try
			{
				var bareEntry = (Element as StandardEntry);
				try
				{
					Control.Font = UIFont.SystemFontOfSize((nfloat)bareEntry.TextSize*5.0f);
				}
                catch
                {
				}
				//Control.BorderStyle = UITextBorderStyle.None;
                if ((Element as StandardEntry).HasFrame)
                {
                    this.Control.Layer.BorderColor = UIColor.LightGray.CGColor;
                }
                else
                {
                    Control.Layer.BorderColor = Color.Transparent.ToCGColor();
                }

				Control.TextColor = bareEntry.TextColor.ToUIColor();
				var s = new NSMutableAttributedString (bareEntry.Placeholder);
				s.AddAttribute (UIStringAttributeKey.ForegroundColor,UIColor.Gray,new NSRange(0,bareEntry.Placeholder.Length));
				Control.AttributedPlaceholder = s;
			}
			catch
			{
			}

		}
		protected override void OnElementPropertyChanged (object sender, System.ComponentModel.PropertyChangedEventArgs e)
		{
			base.OnElementPropertyChanged (sender, e);

            if ((Element as StandardEntry).HasFrame)
            {
                Control.BorderStyle = UITextBorderStyle.RoundedRect;
            }
            else
            {
                //Control.Layer.BorderWidth = 0;
                Control.BorderStyle = UITextBorderStyle.None;
            }
		}

	}
}

