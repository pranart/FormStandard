using System;
using Android.Content.PM;
using Android.Util;
using FFImageLoading.Forms.Platform;
using Java.Security;


namespace FormStandard.Droid
{
	public static class Standard
	{
        static public void Initialize()
		{
			//PdfViewRenderer.Initialize();
			StandardEntryRenderer.Initialize();
			StandardPickerRenderer.Initialize();
			
			HybridWebViewRenderer.Initialize();
			StandardNavigationRenderer.Initialize();
			//FacebookLoginPageRenderer.Initialize();
			//InstagramLoginPageRenderer.Initialize();
			StandardDate.Initialize();
            StandardEditorRenderer.Initialize();
			StandardViewCellRenderer.Initialize();
            StandardLabelRenderer.Initialize();
            BorderlessPickerRenderer.Init();
            //BottomBarPageRenderer.Initialize();
            CachedImageRenderer.Init(true);
		}
        /*public static void GetHashFacebook()
        {
            try
            {
                PackageInfo info = PackageManager.GetPackageInfo(
                            "th.in.xamarin.muka",
                            PackageInfoFlags.Signatures);
                foreach (Android.Content.PM.Signature signature in info.Signatures)
                {
                    MessageDigest md = MessageDigest.GetInstance("SHA");
                    md.Update(signature.ToByteArray());
                    byte[] ba = md.Digest();
                    var result = Base64.EncodeToString(ba, Base64Flags.Default);
                    System.Diagnostics.Debug.WriteLine(result);
                }
            }
            catch (PackageManager.NameNotFoundException e)
            {

            }
            catch (NoSuchAlgorithmException e)
            {

            }
        }*/
	}
}
