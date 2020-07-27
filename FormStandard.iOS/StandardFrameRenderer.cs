using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using FormStandard;
using FormStandard.iOS;
using System;

[assembly: ExportRenderer(typeof(StandardFrame), typeof(StandardFrameRenderer))]
namespace FormStandard.iOS
{
    public class StandardFrameRenderer : FrameRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Frame> e)
        {
            try
            {
                base.OnElementChanged(e);
                Layer.ShadowOpacity = 0.1f;
            }
            catch(Exception exc)
            {

            }
        }

        public static void Initialize() { }
    }
}