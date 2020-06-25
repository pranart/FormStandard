using Android.Graphics.Drawables;
using FormStandard;
using FormStandard.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(StandardEditor), typeof(StandardEditorRenderer))]
namespace FormStandard.Droid
{
    public class StandardEditorRenderer : EditorRenderer
    {
        public StandardEditorRenderer()
        {
        }
        static public void Initialize() {}
        protected override void OnElementChanged(ElementChangedEventArgs<Editor> e)
        {
            base.OnElementChanged(e);


            Recreate();

        }
        void Recreate()
        {
            if (this.Control == null) return;
            Control.SetPadding(0,0,0,0);

            Control.SetHintTextColor(Color.Gray.ToAndroid());
            UpdateBorders();
            //Control.SetTextSize(ComplexUnitType.Mm,(Element as StandardEditor).TextSize);
        }
        protected override void OnElementPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (e.PropertyName == StandardEditor.IsBorderErrorVisibleProperty.PropertyName
                || e.PropertyName == StandardEditor.HasFrameProperty.PropertyName)
            {
                UpdateBorders();
            }
        }
        void UpdateBorders()
        {
            GradientDrawable shape = new GradientDrawable();
            shape.SetShape(ShapeType.Rectangle);
            shape.SetCornerRadius(0);

            if ((Element as StandardEditor).HasFrame)
            {
                if ((Element as StandardEditor).IsBorderErrorVisible)
                {
                    shape.SetStroke(3, (Element as StandardEditor).BorderErrorColor.ToAndroid());
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
