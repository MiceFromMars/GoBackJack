using Cysharp.Threading.Tasks;
using GBJ.UILogic;
using System.Collections.Generic;
using UnityEngine;

namespace GBJ.ServicesLogic
{
    public sealed class UIBuilder : IUIBuilder
    {
        private readonly IAssetsProvider _assetsProvider;

        private readonly UIViewsContainer _viewsContainer;

        private Dictionary<WindowType, WindowController> _windowsControllers = new();

        public UIBuilder(IAssetsProvider assetsProvider)
        {
            _assetsProvider = assetsProvider;

            _viewsContainer = Object.FindObjectOfType<UIViewsContainer>();
        }

        public async UniTask<Dictionary<WindowType, WindowController>> Build()
        {
            await UniTask.WhenAll(BuildComingSoonWindow());

            return _windowsControllers;
        }

        private async UniTask BuildComingSoonWindow()
        {
            var view = await _assetsProvider.Instantiate(AssetsKeys.ComingSoonViewKey, _viewsContainer.GetComponent<RectTransform>());
            view.gameObject.SetActive(false);

            _windowsControllers.Add(WindowType.ComingSoon, new ComingSoonController(view.GetComponent<ComingSoonView>()));
        }
    }
}