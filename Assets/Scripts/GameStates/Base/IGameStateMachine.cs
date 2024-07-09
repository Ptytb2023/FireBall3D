namespace GameStates.Base
{
    public interface IGameStateMachine
    {
        void Enter<IState>() where IState : IGameState;
    }
}