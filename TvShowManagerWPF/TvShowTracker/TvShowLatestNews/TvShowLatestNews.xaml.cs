using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TvShowManagerWPF.TvShowTracker.TvShowLatestNews
{
    /// <summary>
    /// Interaction logic for TvShowLatestNews.xaml
    /// </summary>
    public partial class TvShowLatestNews : UserControl
    {
        public TvShowLatestNews()
        {
            InitializeComponent();
        }

        private void TvShowLatestNews_OnLoaded(object sender, RoutedEventArgs e)
        {
            if (DesignerProperties.GetIsInDesignMode(new DependencyObject()))
                return;

            
        }
    }
}
