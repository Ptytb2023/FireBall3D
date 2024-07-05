namespace GameStates.Base
{
    public interface IGameState
    {
        public void Enter();
        public void Exit();


        public class Empty : IGameState
        {
            public void Enter() { }

            public void Exit() { }
        }
    }
}
