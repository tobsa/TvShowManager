using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace TvShowManagerWPF.TvShowTracker
{
    public class ImageRadioButton : RadioButton
    {
        static ImageRadioButton()
        {
            
        }

        public ImageSource ImageSource
        {
            get { return (ImageSource)GetValue(ImageSourceProperty); }
            set { SetValue(ImageSourceProperty, value); }
        }
        
        public static readonly DependencyProperty ImageSourceProperty =
            DependencyProperty.Register("ImageSource", typeof(ImageSource), typeof(ImageRadioButton), new UIPropertyMetadata(null));
    }
}
