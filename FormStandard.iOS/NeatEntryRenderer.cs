using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using UIKit;
using CoreText;

using FormStandard;
using FormStandard.iOS;
using Xamarin.Forms.Internals;
using Foundation;
using System;
using System.Diagnostics;

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
				if(element.FontSize==0)
                {
					element.FontSize = Device.GetNamedSize(NamedSize.Default,typeof(Entry));
                }
				try
				{
					if(element.FontAttributes.HasFlag(FontAttributes.Bold))
                    {
						Control.Font = UIFont.FromName("SukhumvitSet-Bold", (nfloat)element.FontSize);

					}
					else
                    {
						Control.Font = UIFont.FromName("SukhumvitSet-Light", (nfloat)element.FontSize);

					}
					//UIFont.SystemFontOfSize((nfloat)element.FontSize);
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
				Control.AttributedPlaceholder = new NSAttributedString
				(
					element.Placeholder,
					font: UIFont.FromName("SukhumvitSet-Light", (nfloat)element.FontSize),
					foregroundColor: placeholderColor.ToUIColor(),
					strokeWidth:1
					
				);


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
				case "FontSize":
				case "TextColor":
					Recreate();
					break;
            }
			base.OnElementPropertyChanged(sender, e);
		}


	}
}

