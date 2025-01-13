using Cysharp.Threading.Tasks;
using GBJ.UILogic;
using System.Collections.Generic;

namespace GBJ.ServicesLogic
{
    public interface IUIBuilder : IService
    {
        UniTask<Dictionary<WindowType, WindowController>> Build();
    }
}