namespace GBJ.InternalLogic
{
    public sealed class LoadLevelState : IState
    {
        private readonly GameStateMachine _gameStateMachine;

        public LoadLevelState(GameStateMachine gameStateMachine)
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