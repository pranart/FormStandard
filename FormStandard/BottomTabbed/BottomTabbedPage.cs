using Xamarin.Forms;

namespace FormStandard
{
	public class BottomTabbedPage : TabbedPage
	{
		public bool FixedMode { get; set; }

		public void RaiseCurrentPageChanged()
		{
			OnCurrentPageChanged();
		}
	}
}