using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TvShowManagerWPF
{
    public interface INavigationState
    {
        void Save();
        void Load();
        Navigation GetNavigation();
    }
}
