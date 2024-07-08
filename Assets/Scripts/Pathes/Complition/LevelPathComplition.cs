using Assets.Scripts.GameStates.States;
using GameStates.Base;

namespace Pathes.Complition
{
    public class LevelPathComplition : IPathComlition
    {
        private readonly IGameStateMachine _stateMachine;

        public LevelPathComplition(IGameStateMachine stateMachine)
        {
            _stateMachine = stateMachine;
        }

        public void Complited() => 
            _stateMachine.Enter<LevelComplitedState>();
    }
}
