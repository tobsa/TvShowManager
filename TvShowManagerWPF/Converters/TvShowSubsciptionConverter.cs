using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace TvShowManagerWPF.Converters
{
    public class TvShowSubsciptionConverter : IValueConverter
    {
        public Style SubscribeStyle { get; set; }
        public Style UnsubscribeStyle { get; set; }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool && (bool) value)
                return SubscribeStyle;

            return UnsubscribeStyle;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
