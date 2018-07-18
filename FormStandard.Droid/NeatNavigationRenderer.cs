using System;
using FormStandard;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
//[assembly: ExportRenderer (typeof (FormStandard.StandardNavigationPage), typeof (FormStandard.Droid.StandardNavigationRenderer))]
namespace FormStandard.Droid
{

	public class StandardNavigationRenderer : NavigationRenderer
	{
		static public void Initialize() { }
		//protected override System.Threading.Tasks.Task<bool> OnPushAsync(Page view, bool animated)
		//{
		//	return base.OnPushAsync(view, animated);
		//}

		//protected override System.Threading.Tasks.Task<bool> OnPopViewAsync(Page page, bool animated)
		//{
		//	return base.OnPopViewAsync(page, animated);
		//}

		//protected override System.Threading.Tasks.Task<bool> OnPopToRootAsync(Page page, bool animated)
		//{
		//	return base.OnPopToRootAsync(page, animated);
		//}
	}
}

