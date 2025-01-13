using GBJ.UILogic;
using System.Collections.Generic;

namespace GBJ.ServicesLogic
{
    public sealed class UIProvider : IUIProvider
    {
        private Dictionary<WindowType, WindowController> _windowsControllers;

        public void Initialize(Dictionary<WindowType, WindowController> controllers)
        {
            _windowsControllers = controllers;
        }

        public void ShowWindow(WindowType windowType, bool animIsPlayed = true)
        {
            _windowsControllers[windowType].Show(animIsPlayed);
        }

        public void HideWindow(WindowType windowType, bool animIsPlayed = true)
        {
            _windowsControllers[windowType].Hide(animIsPlayed);
        }

        public WindowController GetWindow(WindowType windowType)
        {
            return _windowsControllers[windowType];
        }
    }
}
