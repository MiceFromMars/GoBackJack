using GBJ.ServicesLogic;

namespace GBJ.InternalLogic
{
    public sealed class InitState : IState
    {
        private readonly GameStateMachine _gameStateMachine;

        public InitState(GameStateMachine gameStateMachine)
        {
            _gameStateMachine = gameStateMachine;
        }

        public void Enter()
        {
            BindServices();

            _gameStateMachine.Enter<BootState>();
        }

        private void BindServices()
        {
            BindGameStateMachine();
            BindAssetsProvider();
            BindUIBuilder();
            BindUIProvider();
        }

        private void BindGameStateMachine()
        {
            Services.Container.AddService<IGameStateMachine>(_gameStateMachine);
        }

        private void BindAssetsProvider()
        {
            var assetsProvider = new AssetsProvider();
            Services.Container.AddService<IAssetsProvider>(assetsProvider);
            assetsProvider.Initialize();
        }

        private void BindUIBuilder()
        {
            var assetsProvider = Services.Container.GetService<IAssetsProvider>();
            Services.Container.AddService<IUIBuilder>(new UIBuilder(assetsProvider));
        }

        private void BindUIProvider()
        {
            Services.Container.AddService<IUIProvider>(new UIProvider());
        }

        public void Exit()
        {

        }
    }
}