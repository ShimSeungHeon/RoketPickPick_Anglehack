using System;
using System.Globalization;
using System.Windows.Data;

namespace RoketPickPick.Converters
{
    public class FixedValueConverter : IValueConverter
    {
        public double FixedValue { get; set; }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return FixedValue;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
