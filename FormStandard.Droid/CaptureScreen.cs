using Xamarin.Forms;

using Android.OS;
using Android.Views;
using Android.App;
using Android.Graphics;
using System.IO;
using System.Diagnostics;
using FormStandard.Droid;
using Android.Media;
using System;
using Android.Provider;
using Android.Content;

[assembly:Dependency(typeof(CaptureScreen))]
namespace FormStandard.Droid
{
	public class CaptureScreen : ICaptureScreen
	{
		public CaptureScreen()
		{
		}
        public void CaptureScreenToAlbum()
        {
            Android.Views.View v1 = (Forms.Context as Activity).Window.DecorView.RootView;
            v1.DrawingCacheEnabled = true;
            Bitmap bitmap = Bitmap.CreateBitmap(v1.DrawingCache);
            v1.DrawingCacheEnabled = false;
            SaveImageToAlbum(bitmap);
        }

        public void SaveImageToAlbum(object oImage)
		{
            Bitmap bitmap = oImage as Bitmap;
            if (bitmap == null) throw new ArgumentException();

			string dateNow = System.DateTime.Now.ToString("yyMMddhhmmss");
			try
			{
				string mPath = System.IO.Path.Combine((string)Android.OS.Environment.ExternalStorageDirectory, "Printzy");
				System.IO.Directory.CreateDirectory(mPath);
				mPath = System.IO.Path.Combine(mPath,dateNow + ".jpg");

				using(FileStream imageFile = new FileStream(mPath,FileMode.OpenOrCreate))
				{
					int quality = 100;
					bitmap.Compress(Bitmap.CompressFormat.Jpeg, quality, imageFile);
					imageFile.Flush();
					imageFile.Close();
				}
                MediaStore.Images.Media.InsertImage(Forms.Context.ContentResolver, bitmap, "Screen Capture", "Screen Capture");
                MediaScannerConnection.ScanFile(Forms.Context,new string[]{mPath},null,new TempObject());
			}
			catch(Exception exc)
			{
				System.Diagnostics.Debug.WriteLine(exc.ToString());
			}
		}

    }
    public class TempObject : Java.Lang.Object,MediaScannerConnection.IOnScanCompletedListener
    {
		public void OnScanCompleted(string path, Android.Net.Uri uri)
	    {

    	}

    }
}
