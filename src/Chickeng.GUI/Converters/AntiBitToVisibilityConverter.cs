using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace Chickeng.GUI.Converters
{
    public class AntiBitToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int bValue = 0;
            if (value is int)
            {
                bValue = (int)value;
            }
            else if (value is Nullable<int>)
            {
                Nullable<int> tmp = (Nullable<int>)value;
                bValue = tmp.HasValue ? tmp.Value : 0;
            }
            return bValue == 0 ? Visibility.Visible : Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is Visibility)
            {
                return (Visibility)value == Visibility.Visible ? 0 : 1;
            }
            else
            {
                return 1;
            }
        }
    }
}
