using System;
using System.Collections.Generic;
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
using TvShowManagerLibrary;
using TvShowManagerWPF.ViewModels;

namespace TvShowManagerWPF.UserControls
{
    public partial class UCTvShowDetails : UserControl
    {
        private readonly TvShowService service = new TvShowService();

        public UCTvShowDetails()
        {
            InitializeComponent();
        }

        private void Command_SubscriptionCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void Command_SubscriptionExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            var show = (DataContext as SearchedTvShowsViewModel)?.TvShowDetails;

            if (service.IsSubscribing(show))
                service.Unsubscribe(show);
            else 
                service.Subscribe(show);
        }
    }
}
