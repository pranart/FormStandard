using Xamarin.Forms;

namespace FormStandard
{
    public class XNativeBasePageView : ContentPage
    {
        #region for bottom bar page

        public void SendAppearing()
        {
            OnAppearing();
        }

        public void SendDisappearing()
        {
            OnDisappearing();
        }

        #endregion
    }
}
