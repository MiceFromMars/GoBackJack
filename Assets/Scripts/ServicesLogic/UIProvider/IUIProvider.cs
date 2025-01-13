using GBJ.UILogic;
using System.Collections.Generic;

namespace GBJ.ServicesLogic
{
    public interface IUIProvider : IService
    {
        void Initialize(Dictionary<WindowType, WindowController> controllers);
        void ShowWindow(WindowType windowType, bool withAnim = true);
        void HideWindow(WindowType windowType, bool withAnim = true);
        WindowController GetWindow(WindowType windowType);
    }
}