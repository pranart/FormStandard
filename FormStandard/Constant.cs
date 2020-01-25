using System;
using Xamarin.Forms;
using System.Linq;
using System.Text.RegularExpressions;
using Xamarin.Forms.Internals;
using System;

[assembly: Preserve]
namespace FormStandard
{
    public class Constant
    {
        static public Func<bool> IsInitialized { get; set; }
        static public int Scale(int x)
        {
            if (Device.Idiom == TargetIdiom.Tablet)
            {
                return 2 * x;
            }
            return x;
        }
        static public double Scale(double x)
        {
            if (Device.Idiom == TargetIdiom.Tablet)
            {
                return 2 * x;
            }
            return x;
        }
        static public ContentPage HomePage { get; set; }
        static public int RepeatWebServiceCount = int.MaxValue;
        static public INavigation INavigation { get; set; }

        static public bool CheckID13(string ID)
        {
            Regex regex = new Regex("[0-9]{13}");
            return regex.IsMatch(ID);
        }
        static public bool CheckWebSite(string url)
        {
            url = url.Trim();
            Regex regex = new Regex("^(http\\:\\/\\/|https\\:\\/\\/)?([a-z0-9A-Z][a-z0-9A-Z\\-]*\\.)+[a-z0-9A-Z][a-z0-9A-Z\\-]*$");
            return regex.IsMatch(url);
        }
        static public bool CheckEmail(string email)
        {
            email = email.Trim();
            Regex regex = new Regex(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$");
            return regex.IsMatch(email);
        }
        static public bool CheckZipCode(string ZipCode)
        {
            ZipCode = ZipCode.Trim();
            Regex regex = new Regex("[0-9]{5}");
            return regex.IsMatch(ZipCode);
        }
        static public double FontSpecialMicro;
        static public double FontMicro;
        static public double FontSmaller;
        static public double FontSmallest;

        static public double FontSmall;//= Standard.Font((Device.OS == TargetPlatform.iOS) ? Device.GetNamedSize(NamedSize.Micro, typeof(Label)) : Device.GetNamedSize(NamedSize.Small, typeof(Label)));
        static public double FontMiddle;
        static public double FontDefault;// = Standard.Font((Device.OS == TargetPlatform.iOS) ? Device.GetNamedSize(NamedSize.Small, typeof(Label)) : Device.GetNamedSize(NamedSize.Default, typeof(Label)));
        static public double FontMedium;// = Standard.Font((Device.OS == TargetPlatform.iOS) ? Device.GetNamedSize(NamedSize.Default, typeof(Label)) : Device.GetNamedSize(NamedSize.Medium, typeof(Label)));
        static public double FontLarge;// = Standard.Font((Device.OS == TargetPlatform.iOS) ? Device.GetNamedSize(NamedSize.Medium, typeof(Label)) : Device.GetNamedSize(NamedSize.Large, typeof(Label)));
        static public double FontLarger;// = Standard.Font((Device.OS == TargetPlatform.iOS) ? Device.GetNamedSize(NamedSize.Large, typeof(Label)) : Device.GetNamedSize(NamedSize.Large, typeof(Label)) * 1.1);
        static public double FontBig;// = Standard.Font((FontLarge + FontMedium) / 2);
        static public double FontLargest;// = Standard.Font((Device.OS == TargetPlatform.iOS) ? Device.GetNamedSize(NamedSize.Large, typeof(Label)) * 1.1 : Device.GetNamedSize(NamedSize.Large, typeof(Label)) * 1.2);
        static public double FontHuge;// = Standard.Font((Device.OS == TargetPlatform.iOS) ? Device.GetNamedSize(NamedSize.Large, typeof(Label)) * 1.2 : Device.GetNamedSize(NamedSize.Large, typeof(Label)) * 1.3);
        static public double FontHuger;// = Standard.Font((Device.OS == TargetPlatform.iOS) ? Device.GetNamedSize(NamedSize.Large, typeof(Label)) * 1.3 : Device.GetNamedSize(NamedSize.Large, typeof(Label)) * 1.4);
        static public double FontHugest;// = Standard.Font((Device.OS == TargetPlatform.iOS) ? Device.GetNamedSize(NamedSize.Large, typeof(Label)) * 1.4 : Device.GetNamedSize(NamedSize.Large, typeof(Label)) * 1.5);

        static public void Initialize()
        {
            FontSpecialMicro = Standard.Font((Device.RuntimePlatform == Device.iOS) ? Device.GetNamedSize(NamedSize.Micro, typeof(Label)) / 2.0 : Device.GetNamedSize(NamedSize.Micro, typeof(Label)) / 2.1);
            FontMicro = Standard.Font((Device.RuntimePlatform == Device.iOS) ? Device.GetNamedSize(NamedSize.Micro, typeof(Label)) / 1.8 : Device.GetNamedSize(NamedSize.Micro, typeof(Label)) / 1.4);
            FontSmallest = Standard.Font((Device.RuntimePlatform == Device.iOS) ? Device.GetNamedSize(NamedSize.Micro, typeof(Label)) / 1.7 : Device.GetNamedSize(NamedSize.Small, typeof(Label)) / 1.5);
            FontSmaller = Standard.Font((Device.RuntimePlatform == Device.iOS) ? Device.GetNamedSize(NamedSize.Micro, typeof(Label)) / 1.4 : Device.GetNamedSize(NamedSize.Small, typeof(Label)) / 1.3);

            FontSmall = Standard.Font((Device.RuntimePlatform == Device.iOS) ? Device.GetNamedSize(NamedSize.Micro, typeof(Label)) : Device.GetNamedSize(NamedSize.Small, typeof(Label)));
            FontDefault = Standard.Font((Device.RuntimePlatform == Device.iOS) ? Device.GetNamedSize(NamedSize.Small, typeof(Label)) : Device.GetNamedSize(NamedSize.Default, typeof(Label)));
            FontMedium = Standard.Font((Device.RuntimePlatform == Device.iOS) ? Device.GetNamedSize(NamedSize.Default, typeof(Label)) : Device.GetNamedSize(NamedSize.Medium, typeof(Label)));
            FontBig = Standard.Font((FontLarge + FontMedium) / 2);
            FontLarge = Standard.Font((Device.RuntimePlatform == Device.iOS) ? Device.GetNamedSize(NamedSize.Medium, typeof(Label)) : 0.9 * Device.GetNamedSize(NamedSize.Medium, typeof(Label)));
            FontLarger = Standard.Font((Device.RuntimePlatform == Device.iOS) ? Device.GetNamedSize(NamedSize.Large, typeof(Label)) : 0.9 * Device.GetNamedSize(NamedSize.Large, typeof(Label)));
            FontLargest = Standard.Font((Device.RuntimePlatform == Device.iOS) ? Device.GetNamedSize(NamedSize.Large, typeof(Label)) * 1.1 : Device.GetNamedSize(NamedSize.Large, typeof(Label)) * 0.9);
            FontHuge = Standard.Font((Device.RuntimePlatform == Device.iOS) ? Device.GetNamedSize(NamedSize.Large, typeof(Label)) * 1.2 : Device.GetNamedSize(NamedSize.Large, typeof(Label)) * 0.9);
            FontHuger = Standard.Font((Device.RuntimePlatform == Device.iOS) ? Device.GetNamedSize(NamedSize.Large, typeof(Label)) * 1.3 : Device.GetNamedSize(NamedSize.Large, typeof(Label)) * 0.95);
            FontHugest = Standard.Font((Device.RuntimePlatform == Device.iOS) ? Device.GetNamedSize(NamedSize.Large, typeof(Label)) * 1.4 : Device.GetNamedSize(NamedSize.Large, typeof(Label)) * 1.0);
            FontMiddle = (FontSmall + FontMedium) / 1.7;
        }

        public static double RadianFromDegree(double degree)
        {
            return (degree*Math.PI)/ 180.0;
        }
        public static double DegreeFromRadiann(double radian)
        {
            return (radian / Math.PI) * 180.0;
        }
        public static double Distance(double lat1, double lng1, double lat2, double lng2)
        {
            var theta = lng1 - lng2;

            var distance = Math.Sin(RadianFromDegree(lat1) * Math.Sin(RadianFromDegree(lat2))
                + Math.Cos(RadianFromDegree(lat1)) * Math.Cos(RadianFromDegree(lat2))
                * Math.Cos(theta));
            distance = Math.Acos(distance);
            distance = distance * 60 * 1.1515;
            distance = distance * 1.609344;
            return distance;

        }
	}
}

