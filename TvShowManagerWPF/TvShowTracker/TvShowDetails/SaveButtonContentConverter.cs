using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace TvShowManagerWPF.TvShowTracker.TvShowDetails
{
    public class SaveButtonContentConverter : IValueConverter
    {
        public string CustomName { get; set; }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return "Save";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
