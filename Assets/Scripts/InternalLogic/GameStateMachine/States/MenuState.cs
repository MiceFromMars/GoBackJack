using GBJ.ServicesLogic;
using GBJ.UILogic;

namespace GBJ.InternalLogic
{
    public sealed class MenuState : IState
    {
        private readonly GameStateMachine _gameStateMachine;
        private IUIProvider _uiProvider;

        public MenuState(GameStateMachine gameStateMachine)
        {
            _gameStateMachine = gameStateMachine;
        }

        private void InitServices()
        {
            _uiProvider ??= Services.Container.GetService<IUIProvider>();
        }

        public void Enter()
        {
            InitServices();

            _uiProvider.ShowWindow(WindowType.ComingSoon);
        }

        public void Exit()
        {

        }
    }
}
