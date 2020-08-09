using System;
using System.IO;
using FormStandard.iOS;
using Foundation;
using Photos;
using UIKit;
using Xamarin.Forms;

[assembly:Dependency(typeof(SaveToAlbum))]
namespace FormStandard.iOS
{
    public class SaveToAlbum : ISaveToAlbum
    {
        public SaveToAlbum()
        {
        }

        public void SaveImageStreamToAlbum(string fileName, Stream stream)
        {
            PHPhotoLibrary.RequestAuthorization(status =>
            {
                switch (status)
                {
                    case PHAuthorizationStatus.Authorized:
                        // Add code do run if user authorized permission, if needed.
                        var documentsDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
                        string imageFilename = System.IO.Path.Combine(documentsDirectory + "/AppPhoto", fileName);

                        stream.Seek(0, SeekOrigin.Begin);
                        var data = NSData.FromStream(stream);

                        var imageData = new UIImage(data);
                        Device.BeginInvokeOnMainThread(() =>
                        {
                            imageData.SaveToPhotosAlbum((image, err) =>
                            {
                                if (err == null)
                                    new UIAlertView("", "Saved", null, "OK", null).Show();
                                else
                                    new UIAlertView("", "Failed", null, "OK", null).Show();
                            });

                        });
                        break;
                    case PHAuthorizationStatus.Denied:
                        // Add code do run if user denied permission, if needed.
                        break;
                    case PHAuthorizationStatus.Restricted:
                        // Add code do run if user restricted permission, if needed.
                        break;
                    default:
                        break;
                }
            });
            
        }
    }
}
