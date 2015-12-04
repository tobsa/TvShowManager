using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TvShowManagerWPF
{
    public class NavigationStateService
    {
        private List<INavigationState> navigationStates = new List<INavigationState>();
        private int currentIndex = -1;

        public void AddNavigationState(INavigationState state, bool cleanNavigationState = true)
        {
            if (cleanNavigationState && navigationStates.Count > 0 && currentIndex < navigationStates.Count - 1)
                navigationStates = navigationStates.Take(currentIndex + 1).ToList();

            navigationStates.Add(state);
            currentIndex++;
        }

        public Navigation NavigateForward()
        {
            currentIndex++;
            if (currentIndex > navigationStates.Count - 1)
                currentIndex = navigationStates.Count - 1;

            navigationStates[currentIndex].Load();
            return navigationStates[currentIndex].GetNavigation();
        }

        public Navigation NavigateBackward()
        {
            currentIndex--;
            if (currentIndex < 0)
                currentIndex = 0;

            navigationStates[currentIndex].Load();
            return navigationStates[currentIndex].GetNavigation();
        }
    }
}
