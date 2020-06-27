using System;
using Xamarin.Forms;

namespace FormStandard.Converter
{
    public class IsNotHaveVoidConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return !((value as string) ?? "void").Contains("void");
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return value;
        }
    }
}
