using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace TvShowManagerWPF
{
    public static class CommandBindings
    {
        public static RoutedUICommand Search = new SearchCommand();
        public static RoutedUICommand Subscription = new SubscriptionCommand();
    }

    public class SearchCommand : RoutedUICommand
    {
        public SearchCommand() :
            base("Search", "Search", typeof (Window))
        {
        }
    }

    public class SubscriptionCommand : RoutedUICommand
    {
        public SubscriptionCommand() :
            base("Subscription", "Subscription", typeof (Window))
        {
        }
    }
}
