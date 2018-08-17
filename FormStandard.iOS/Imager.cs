using System;
using System.IO;
using System.Threading.Tasks;
using System.Drawing;
using UIKit;
using CoreGraphics;
using FormStandard.iOS;
using Xamarin.Forms;
using System.Collections.Generic;
using Foundation;

[assembly:Dependency(typeof(FormStandard.iOS.Imager))]
namespace FormStandard.iOS
{

    public class Imager : IImage
	{
        
		public byte[] ResizeImage(byte[] imageData, float width, float height)
		{
			if (imageData == null) throw new ArgumentNullException();
			if (width <= 0) throw new ArgumentException();
			if (height <= 0) throw new ArgumentException();

			return (ResizeImage(ImageFromByteArray(imageData), width, height) as UIImage).AsJPEG().ToArray();
		}


		public object ResizeImage(object imageData, float width, float height)
		{
			if (imageData == null) throw new ArgumentNullException();
			if (width <= 0) throw new ArgumentException();
			if (height <= 0) throw new ArgumentException();

			UIImage originalImage = imageData as UIImage;
			UIImageOrientation orientation = originalImage.Orientation;

			//create a 24bit RGB image
			using (CGBitmapContext context = new CGBitmapContext(IntPtr.Zero,
												 (int)width, (int)height, 8,
												 (int)(4 * width), CGColorSpace.CreateDeviceRGB(),
												 CGImageAlphaInfo.PremultipliedFirst))
			{

				RectangleF imageRect = new RectangleF(0, 0, width, height);

				// draw the image
				context.DrawImage(imageRect, originalImage.CGImage);

				UIKit.UIImage resizedImage = UIKit.UIImage.FromImage(context.ToImage(), 0, orientation);

                // save the image as a jpeg
                return resizedImage;
			}
		}

		public static UIKit.UIImage ImageFromByteArray(byte[] data)
		{
			if (data == null) throw new ArgumentNullException();

			UIKit.UIImage image;
			try
			{
				image = new UIKit.UIImage(Foundation.NSData.FromArray(data));
			}
			catch (Exception e)
			{
				Console.WriteLine("Image load failed: " + e.Message);
				return null;
			}
			return image;
		}

		public object CropImage(object imageData, int left, int top, int right, int bottom)
		{
			if (imageData == null) throw new ArgumentNullException();
			if (left< 0) throw new ArgumentException();
			if (top< 0) throw new ArgumentException();
			if (right< 0) throw new ArgumentException();
			if (bottom< 0) throw new ArgumentException();

			UIImage sourceImage = imageData as UIImage;
			CGRect rect = new CGRect(left, top, right - left + 1, bottom - top + 1);
			UIImage destinationImage = new UIImage(sourceImage.CGImage.WithImageInRect(rect));
			return destinationImage;
		}

		public object LoadImage(string path)
		{
			if (string.IsNullOrWhiteSpace(path)) throw new ArgumentNullException();

			return UIImage.FromFile(path);
		}

		public int WidthOfImage(object image)
		{
			if (image == null) throw new ArgumentNullException();

			UIImage bitmap = image as UIImage;
			return (int)bitmap.Size.Width;
		}

		public int HeightOfImage(object image)
		{
			if (image == null) throw new ArgumentNullException();

			UIImage bitmap = image as UIImage;
			return (int)bitmap.Size.Height;
		}

		public byte[] ByteArrayFromObject(object image)
		{
			if (image == null) throw new ArgumentNullException();

			UIImage bitmap = image as UIImage;
			if (bitmap == null) throw new ArgumentException();

			return bitmap.AsJPEG().ToArray();
		}

        public object ObjectFromByteArray(byte[] imageByteArray) {
            var data = NSData.FromArray(imageByteArray);
            return UIImage.LoadFromData(data);
        }

        public Task<object> RotatedByDegrees(object oSource, double doubleDegrees)
        {
            nfloat degrees = (nfloat)doubleDegrees;
            var TaskRotate = new TaskCompletionSource<object>();
            UIImage uiSourceImage = oSource as UIImage;
            Device.BeginInvokeOnMainThread(() =>
            {
                // calculate the size of the rotated view's containing box for our drawing space
                UIView rotatedViewBox = new UIView(new CGRect(0, 0, uiSourceImage.Size.Width, uiSourceImage.Size.Height));

                CGAffineTransform t = CGAffineTransform.MakeRotation(RadiansFromDegree(degrees));
                rotatedViewBox.Transform = t;
                CGSize rotatedSize = rotatedViewBox.Frame.Size;

                //Create the bitmap context
                UIGraphics.BeginImageContext(rotatedSize);

                UIImage rotatedImage;
                using (CGContext bitmap = UIGraphics.GetCurrentContext())
                {
                    // Move the origin to the middle of the image so we will rotate and scale around the center.
                    bitmap.TranslateCTM(rotatedSize.Width / 2, rotatedSize.Height / 2);

                    // Rotate the image context
                    bitmap.RotateCTM(RadiansFromDegree(degrees));

                    // Now, draw the rotated/scaled image into the context
                    bitmap.ScaleCTM(1.0f, -1.0f);

                    bitmap.DrawImage(new CGRect(-uiSourceImage.Size.Width / 2, -uiSourceImage.Size.Height / 2, uiSourceImage.Size.Width, uiSourceImage.Size.Height), uiSourceImage.CGImage);

                    rotatedImage = UIGraphics.GetImageFromCurrentImageContext();

                }
                UIGraphics.EndImageContext();

                TaskRotate.SetResult(rotatedImage);
            });

            return TaskRotate.Task;

        }



        nfloat RadiansFromDegree(nfloat degrees) { return degrees * (nfloat)Math.PI / (nfloat)180.0; }
    }
}


