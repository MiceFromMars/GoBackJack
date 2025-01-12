namespace GBJ.InternalLogic
{
    public sealed class MenuState : IState
    {
        private readonly GameStateMachine _gameStateMachine;

        public MenuState(GameStateMachine gameStateMachine)
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
