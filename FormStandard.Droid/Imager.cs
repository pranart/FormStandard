using System;
using System.Threading.Tasks;
using System.IO;

using Android.Graphics;
using Xamarin.Forms;
using FormStandard.Droid;
using System.Collections.Generic;
using Android.Runtime;

[assembly:Dependency(typeof(Imager))]
namespace FormStandard.Droid
{
    [Preserve]
	public class Imager : IImage
	{
		public byte[] ByteArrayFromObject(object image)
		{
			if (image == null) throw new ArgumentNullException();
			Bitmap bitmap = image as Bitmap;
			if (bitmap == null) throw new ArgumentException();

			using (MemoryStream ms = new MemoryStream())
			{
				bitmap.Compress(Bitmap.CompressFormat.Jpeg, 100, ms);
				return ms.ToArray();
			}
		}

		public object CropImage(object imageData, int left, int top, int right, int bottom)
		{
			if (imageData == null) 
				throw new ArgumentNullException();
			if (left == -1) left = 0;
			if (left < 0) 
				throw new ArgumentException();
			if (top == -1) top = 0;
			if (top < 0) 
				throw new ArgumentException();
			if (right < 0) 
				throw new ArgumentException();
			if (bottom < 0) 
				throw new ArgumentException();

			byte[] mem;
			Bitmap sourceBitmap = imageData as Bitmap;
			using (MemoryStream ms = new MemoryStream())
			{
				sourceBitmap.Compress(Bitmap.CompressFormat.Jpeg, 100, ms);
				mem = ms.ToArray();
			}

			BitmapRegionDecoder decoder = BitmapRegionDecoder.NewInstance(mem, 0, mem.Length, false);
			Bitmap croppedBitmap= decoder.DecodeRegion(new Rect(left,top,right,bottom), null);
			decoder.Recycle();
			return croppedBitmap;
		}

		public int HeightOfImage(object image)
		{
			if (image == null) throw new ArgumentNullException();

			Bitmap bitmap = image as Bitmap;
			return bitmap.Height;
		}

		public object LoadImage(string path)
		{
			if (string.IsNullOrWhiteSpace(path)) throw new ArgumentNullException();

			BitmapFactory.Options options = new BitmapFactory.Options();
			options.InPreferredConfig = Bitmap.Config.Argb8888;
			options.InMutable = true;
			return BitmapFactory.DecodeFile(path, options);
		}

        public object ObjectFromByteArray(byte[] imageByteArray) 
        {
            return BitmapFactory.DecodeByteArray(imageByteArray, 0, imageByteArray.Length);
        }

        public byte[] ResizeImage(byte[] imageData, float width, float height)
		{
			if (imageData == null) throw new ArgumentNullException();
			if (width <= 0) throw new ArgumentException();
			if (height <= 0) throw new ArgumentException();

            // Load the bitmap
            using (Bitmap originalImage = BitmapFactory.DecodeByteArray(imageData, 0, imageData.Length))
            {
                //using (Bitmap resizedImage = ResizeImage(originalImage, width, height) as Bitmap)
                //{

                    using (MemoryStream ms = new MemoryStream())
                    {
                        originalImage.Compress(Bitmap.CompressFormat.Jpeg, 100, ms);
                        return ms.ToArray();
                    }
                //}
            }
		}
        public object ResizeImage(object imageData, float width, float height)
        {
			if (imageData == null) throw new ArgumentNullException();
			if (width <= 0) throw new ArgumentException();
			if (height <= 0) throw new ArgumentException();

            // Load the bitmap
			Bitmap originalImage = imageData as Bitmap;
            Bitmap resizedImage = Bitmap.CreateScaledBitmap(originalImage, (int)width, (int)height, false);
            return resizedImage;
        }

		public int WidthOfImage(object image)
		{
			if (image == null) throw new ArgumentNullException();

			Bitmap bitmap = image as Bitmap;
			return bitmap.Width;

		}


        Task<object> IImage.RotatedByDegrees(object src, double degrees)
        {
            throw new NotImplementedException();
        }
    }
}
