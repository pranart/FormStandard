using System;
using System.Globalization;
using System.Threading;
using FormStandard.Droid;
using Xamarin.Forms;

[assembly: Dependency(typeof(StandardDate))]
namespace FormStandard.Droid
{
	public class StandardDate : IDate
	{
		public StandardDate()
		{
		}
		public static void Initialize()
		{

		}
        public string ToChristainDateString(DateTime dateTime)
        {
            return ToChristainDateString(dateTime, "yyyy-M-d HH:mm:ss");

        }

        public string ToBuddhishDateString(DateTime dateTime)
        {
            return ToBuddhishDateString(dateTime, "yyyy-M-d HH:mm:ss");
        }


        public string ToChristainDateString(DateTime dateTime, string format)
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
            return dateTime.ToString(format);

        }

        public string ToBuddhishDateString(DateTime dateTime, string format)
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("th-TH");
            return dateTime.ToString(format);
        }
	}
}
