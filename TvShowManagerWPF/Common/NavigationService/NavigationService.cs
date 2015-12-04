using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TvShowManagerWPF.Common.NavigationService
{
    [Serializable]
    public class NavigationService
    {
        private readonly List<BaseViewModel> states = new List<BaseViewModel>();
        private int currentIndex = -1;

        public void AddState(BaseViewModel state)
        {
            states.Add(state);
            currentIndex++;
        }

        public void NavigateForward()
        {
            currentIndex++;
            if (currentIndex > states.Count - 1)
                currentIndex = states.Count - 1;
        }

        public void NavigateBackward()
        {
            currentIndex--;
            if (currentIndex < 0)
                currentIndex = 0;
        }

        public BaseViewModel CurrentViewModel => states[currentIndex];
    }
}
