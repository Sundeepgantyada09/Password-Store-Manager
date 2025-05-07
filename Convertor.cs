using System;
using System.Globalization;

namespace nitesh_passman
{
    public class BooleanToPasswordConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool showPassword && showPassword)
            {
                return parameter?.ToString() ?? string.Empty;
            }

            return "********";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

}

