namespace GBJ.InternalLogic
{
    public sealed class PlayState : IState
    {
        private readonly GameStateMachine _gameStateMachine;

        public PlayState(GameStateMachine gameStateMachine)
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
