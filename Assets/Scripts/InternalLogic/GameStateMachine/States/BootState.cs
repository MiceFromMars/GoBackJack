namespace GBJ.InternalLogic
{
    public sealed class BootState : IState
    {
        private readonly GameStateMachine _gameStateMachine;

        public BootState(GameStateMachine gameStateMachine)
        {
            _gameStateMachine = gameStateMachine;
        }

        public async void Enter()
        {

        }

        public void Exit()
        {

        }
    }
}
