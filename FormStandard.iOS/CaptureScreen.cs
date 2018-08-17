using System;
using CoreGraphics;
using FormStandard.iOS;
using UIKit;
using Xamarin.Forms;
using Foundation;

[assembly:Dependency(typeof(CaptureScreen))]
namespace FormStandard.iOS
{
	public class CaptureScreen : ICaptureScreen
	{
		public CaptureScreen()
		{
		}

        public void CaptureScreenToAlbum()
		{
			CGSize screenSize = UIScreen.MainScreen.ApplicationFrame.Size;
			CGColorSpace colorSpaceRef = CGColorSpace.CreateDeviceRGB();
			CGBitmapContext ctx = new CGBitmapContext(IntPtr.Zero, (nint)screenSize.Width, (nint)screenSize.Height, 8, 4 * (int)screenSize.Width, colorSpaceRef, CGImageAlphaInfo.PremultipliedLast);
			ctx.TranslateCTM((nfloat)0, (nfloat)(screenSize.Height));
			ctx.ScaleCTM((nfloat)1.0,(nfloat)(-1.0));
			CurrentViewController().View.Layer.RenderInContext(ctx);
			CGImage cgImage = ctx.ToImage();
			UIImage image = new UIImage(cgImage);
            SaveImageToAlbum(image);
			cgImage.Dispose();
			ctx.Dispose();

		}
        public void SaveImageToAlbum(object image)
        {
            UIImage uiImage = image as UIImage;
            if (uiImage == null) throw new ArgumentException();
            Xamarin.Forms.Device.BeginInvokeOnMainThread(() =>
            {
                uiImage.SaveToPhotosAlbum((UIImage img, Foundation.NSError error) =>
                {

                });

            });
        }
		UIViewController CurrentViewController()
		{
			var window = UIApplication.SharedApplication.KeyWindow;
			var vc = window.RootViewController;
			while (vc.PresentedViewController != null)
			{
			    vc = vc.PresentedViewController;
			}
			return vc;
		}
	}
}
