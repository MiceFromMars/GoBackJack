using GBJ.ServicesLogic;

namespace GBJ.InternalLogic
{
    public interface IGameStateMachine : IService
    {
        void Enter<T>() where T : class, IState;
    }
}