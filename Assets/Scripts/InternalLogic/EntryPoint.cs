using UnityEngine;

namespace GBJ.InternalLogic
{
    public sealed class EntryPoint : MonoBehaviour
    {
        private static EntryPoint _instance;
        private GameStateMachine _gameStateMachine;

        private void Awake()
        {
            InstantiateAsSingle();
            InitGameStateMachine();
        }

        private void InitGameStateMachine()
        {
            _gameStateMachine = new GameStateMachine();
            _gameStateMachine.Enter<InitState>();
        }

        private void InstantiateAsSingle()
        {
            if (_instance != null && _instance != this)
            {
                Destroy(this);
            }
            else
            {
                _instance = this;
                DontDestroyOnLoad(this);
            }
        }
    }
}
