using System;
namespace FormStandard.Droid
{
	public static class Standard
	{
        static public void Initialize()
		{
			//PdfViewRenderer.Initialize();
			StandardEntryRenderer.Initialize();
			StandardPickerRenderer.Initialize();
			StandardWebViewRenderer.Initialize();
			HybridWebViewRenderer.Initialize();
			StandardNavigationRenderer.Initialize();
			FacebookLoginPageRenderer.Initialize();
			InstagramLoginPageRenderer.Initialize();
			StandardDate.Initialize();
            StandardEditorRenderer.Initialize();
			StandardViewCellRenderer.Initialize();
            StandardLabelRenderer.Initialize();
            BorderlessPickerRenderer.Init();
            //BottomBarPageRenderer.Initialize();
		}
	}
}
