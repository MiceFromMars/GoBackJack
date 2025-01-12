namespace GBJ.InternalLogic
{
    public interface IGameStateMachine 
    {
        void Enter<T>() where T : class, IState;
    }
}