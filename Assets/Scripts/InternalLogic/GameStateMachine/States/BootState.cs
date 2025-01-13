using Cysharp.Threading.Tasks;
using GBJ.ServicesLogic;

namespace GBJ.InternalLogic
{
    public sealed class BootState : IState
    {
        private readonly GameStateMachine _gameStateMachine;
        private IUIBuilder _uiBuilder;
        private IUIProvider _uiProvider;

        public BootState(GameStateMachine gameStateMachine)
        {
            _gameStateMachine = gameStateMachine;
        }

        private void InitServices()
        {
            _uiBuilder ??= Services.Container.GetService<IUIBuilder>();
            _uiProvider ??= Services.Container.GetService<IUIProvider>();
        }

        public async void Enter()
        {
            InitServices();
            await BootUI();
            _gameStateMachine.Enter<MenuState>();
        }

        private async UniTask BootUI()
        {
            var ui = await _uiBuilder.Build();
            _uiProvider.Initialize(ui);
        }

        public void Exit()
        {

        }
    }
}
