using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using FormStandard;
using FormStandard.iOS;

[assembly: ExportRenderer(typeof(StandardFrame), typeof(StandardFrameRenderer))]
namespace FormStandard.iOS
{
    public class StandardFrameRenderer : FrameRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Frame> e)
        {
            base.OnElementChanged(e);
            Layer.ShadowOpacity = 0.1f;
        }

        public static void Initialize() { }
    }
}