using System;
using System.Globalization;
using System.Threading;
using Xamarin.Forms;

[assembly: Dependency(typeof(FormStandard.Thai))]
namespace FormStandard
{
    public class Thai : IThai
    {
        public Thai()
        {
        }

        public void ToThaiCulture()
        {
            var userSelectedCulture = new CultureInfo("th-TH");

            Thread.CurrentThread.CurrentCulture = userSelectedCulture;
        }
    }
}
