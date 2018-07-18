using Xamarin.Forms;
using FormStandard;
using Xamarin.Forms.Platform.Android;

using FormStandard.Droid;
using Android.Util;
using Android.Graphics.Drawables;

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
			Control.SetPadding (0,0,0,0);

            Control.SetHintTextColor (Color.Gray.ToAndroid ());
            Control.SetTextSize (ComplexUnitType.Mm,(float)(Element as StandardEntry).TextSize);
            UpdateBorders();

		}
		protected override void OnElementPropertyChanged (object sender, System.ComponentModel.PropertyChangedEventArgs e)
		{
			base.OnElementPropertyChanged (sender, e);

			if (e.PropertyName == "TextSize") 
			{
				Recreate ();
                UpdateBorders();
				this.Invalidate ();
			}
            else if(e.PropertyName == StandardEntry.IsBorderErrorVisibleProperty.PropertyName
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
                shape.SetStroke(3, Color.Transparent.ToAndroid());
            }

            this.Control.SetBackground(shape);
        }

	}
}

