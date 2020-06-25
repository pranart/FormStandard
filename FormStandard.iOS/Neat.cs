using FFImageLoading.Forms.Platform;


namespace FormStandard.iOS
{
    public class Standard 
	{
		public static void Initialize()
		{
			StandardEntryRenderer.Initialize();
			StandardListViewRenderer.Initialize();
			StandardViewCellRenderer.Initialize();
            HybridWebViewRenderer.Initialize();
			//FacebookLoginPageRenderer.Initialize();
			//InstagramLoginPageRenderer.Initialize();
			StandardDate.Init();
            StandardSafeViewRenderer.Init();
            StandardFrameRenderer.Initialize();
            StandardLabelRenderer.Initialize();
            BorderlessPickerRenderer.Init();
			CachedImageRenderer.Init();

        }
	}
}
