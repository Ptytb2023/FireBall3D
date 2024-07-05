using UnityEngine;

namespace GameStates.Base
{
    [CreateAssetMenu(fileName = nameof(GameStateMachineSo),
      menuName = nameof(ScriptableObject) + "/" + nameof(GameStates) + "/" + nameof(GameStateMachineSo),
      order = 51)]
    public class GameStateMachineSo : ScriptableObject, IGameStateMachine
    {
        [SerializeField] private BaseGameStateSo[] _states;

        private GameStateMachine _stateMachine;

        private void OnEnable() => 
            _stateMachine = new GameStateMachine(_states);

        public void Enter<IState>() where IState : IGameState => 
            _stateMachine.Enter<IState>();
    }
}
