using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using UIKit;
using CoreText;

using NeatLibrary;
using NeatLibrary.iOS;
using Xamarin.Forms.Internals;
using Foundation;
using System;

[assembly: ExportRenderer (typeof (NeatEntry), typeof (NeatEntryRenderer))]
namespace NeatLibrary.iOS
{
    [Xamarin.Forms.Internals.Preserve]
	public class NeatEntryRenderer : EntryRenderer
	{
		public NeatEntryRenderer ()
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
				var bareEntry = (Element as NeatEntry);
				try
				{
					Control.Font = UIFont.SystemFontOfSize((nfloat)bareEntry.TextSize*5.0f);
				}
                catch
                {
				}
				//Control.BorderStyle = UITextBorderStyle.None;
                if ((Element as NeatEntry).HasFrame)
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

            if ((Element as NeatEntry).HasFrame)
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

