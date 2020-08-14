using Xamarin.Forms;
using FormStandard;
using Xamarin.Forms.Platform.Android;

using FormStandard.Droid;
using Android.Util;
using Android.Graphics.Drawables;
using Android.Content.Res;
using Android.Graphics;

[assembly: ExportRenderer (typeof (StandardEntry), typeof (StandardEntryRenderer))]
namespace FormStandard.Droid
{
	public class StandardEntryRenderer : EntryRenderer
	{
		public StandardEntryRenderer ()
		{
		}
		static public void Initialize() { }
		protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Entry> e)

		{
			base.OnElementChanged(e);

			Recreate ();
		}
        void Recreate()
        {

            if (this.Control == null) return;
            var element = (Element as StandardEntry);
            if (element == null) return;
            Control.SetPadding(0, 0, 0, 0);
            Typeface myFont;
            if (element.FontAttributes.HasFlag(FontAttributes.Bold))
            {
                myFont = Typeface.CreateFromAsset(Android.App.Application.Context.Assets, "Kanit-Bold.ttf");

            }
            else
            {
                myFont = Typeface.CreateFromAsset(Android.App.Application.Context.Assets, "Kanit-Regular.ttf");

            }
            Control.Typeface = myFont;
            if (element.FontSize == 0.0)
            {
                element.FontSize = Device.GetNamedSize(NamedSize.Default,typeof(Entry));
            }
            Control.SetHintTextColor (element.PlaceholderColor.ToAndroid());
            Control.SetTextSize (ComplexUnitType.Sp,(float)element.FontSize);
            UpdateBorders();

		}
		protected override void OnElementPropertyChanged (object sender, System.ComponentModel.PropertyChangedEventArgs e)
		{
			base.OnElementPropertyChanged (sender, e);

			if (e.PropertyName == StandardEntry.TextColorProperty.PropertyName
				|| e.PropertyName == StandardEntry.PlaceholderColorProperty.PropertyName
				|| e.PropertyName == StandardEntry.PlaceholderProperty.PropertyName) 
			{
				Recreate ();
                UpdateBorders();
				this.Invalidate ();
			}
            if(e.PropertyName == StandardEntry.IsBorderErrorVisibleProperty.PropertyName
                    || e.PropertyName == StandardEntry.HasFrameProperty.PropertyName)
            {
                UpdateBorders();
            }


		}
		void UpdateBorders()
        {
            GradientDrawable shape = new GradientDrawable();
            shape.SetShape(ShapeType.Rectangle);
            shape.SetCornerRadius(0);

            if ((Element as StandardEntry).HasFrame)
            {
                if (((StandardEntry)this.Element).IsBorderErrorVisible)
                {
                    shape.SetStroke(3, ((StandardEntry)this.Element).BorderErrorColor.ToAndroid());
                }
                else
                {
                    shape.SetStroke(3, Android.Graphics.Color.LightGray);
                    this.Control.SetBackground(shape);
                }
            }
            else
            {
                shape.SetStroke(3, Android.Graphics.Color.Transparent);
            }

            this.Control.SetBackground(shape);
        }

	}
}

