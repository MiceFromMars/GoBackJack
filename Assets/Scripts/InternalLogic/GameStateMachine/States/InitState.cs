namespace GBJ.InternalLogic
{
    public sealed class InitState : IState
    {
        private readonly GameStateMachine _gameStateMachine;

        public InitState(GameStateMachine gameStateMachine)
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