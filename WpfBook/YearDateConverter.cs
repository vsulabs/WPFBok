using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Data;

namespace WpfBook
{
    [ValueConversion(typeof(double), typeof(string))]
    public class YearDateConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter,
            System.Globalization.CultureInfo culture)
        {
            return ((DateTime)value).ToString("yyyy");
        }

        public object ConvertBack(object value, Type targetType, object parameter,
            System.Globalization.CultureInfo culture)
        {
            DateTime date = new DateTime();
            bool succes = DateTime.TryParse((string)value, out date);
            if (!succes)
            {
                CultureInfo info = CultureInfo.InvariantCulture;
                succes = DateTime.TryParseExact((string)value, "yyyy", info, DateTimeStyles.AssumeLocal, out date);
                if (!succes)
                    return date;
            }

            return date;
        }
    }
}
