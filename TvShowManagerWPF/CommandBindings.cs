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
    }

    public class SearchCommand : RoutedUICommand
    {
        public SearchCommand() :
            base("Search", "Search", typeof (Window))
        {
        }
    }
}
