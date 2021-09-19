using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace WpfCarTable.Service
{
    public class NameToBrushConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if ((decimal)value >= 25000000)
            {
                return Brushes.LightGreen;
            }
            else
            {
                return Brushes.Transparent;
            }
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
