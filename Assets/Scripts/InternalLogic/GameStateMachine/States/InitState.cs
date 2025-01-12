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
        }

        private void BindServices()
        {
            BindGameStateMachine();
        }

        private void BindGameStateMachine()
        {
            Services.Container.AddService<IGameStateMachine>(_gameStateMachine);
        }

        public void Exit()
        {

        }
    }
}