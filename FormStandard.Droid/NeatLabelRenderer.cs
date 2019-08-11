using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Android.Widget;
using Android.Util;
using Android.Graphics;
using FormStandard;
using System;
using FormStandard.Shared;
using Android.Content;

[assembly: ExportRenderer(typeof(StandardLabel), typeof(FormStandard.Droid.StandardLabelRenderer))]
namespace FormStandard.Droid
{
    public class StandardLabelRenderer : LabelRenderer 
	{
        public Context FormsContext { get; set; }
        public static void Initialize() { }
        public StandardLabelRenderer(Context context) : base(context)
        {
            FormsContext = context;
        }
		protected override void OnElementChanged (ElementChangedEventArgs<Label> e) {
			base.OnElementChanged(e);
			//var control = new ThaiLineBreakingTextView(FormsContext);
            
			//SetNativeControl(control);
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
                    Typeface font = Typeface.CreateFromAsset(FormsContext.Assets, Element?.StyleId+".ttf");
                    label.Typeface = font;
                }

             }
            catch(System.Exception exc)
            {
                System.Diagnostics.Debug.WriteLine(exc.ToString());
			}
			label.SetTextSize (ComplexUnitType.Dip,(float)fontSize);
		}

		protected override void OnElementPropertyChanged (object sender, System.ComponentModel.PropertyChangedEventArgs e)
		{
			if(e.PropertyName == "Text" || e.PropertyName=="Renderer")
			{
				//(Control as ThaiLineBreakingTextView).SetText2 (Element.Text);			   
			}
			base.OnElementPropertyChanged (sender, e);

			switch(e.PropertyName)
			{
				case "FontSize":
				case "LineLimit":
				case "IsBold":
    				Recreate ();
                    //(Control as ThaiLineBreakingTextView).SetText2(Element.Text);
    				this.Invalidate ();
					break;
			}
		}
	}
}
