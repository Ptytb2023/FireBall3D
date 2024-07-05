using System;
using System.Collections.Generic;

namespace GameStates.Base
{
    public class GameStateMachine : IGameStateMachine
    {
        private readonly Dictionary<Type, IGameState> _states;

        private IGameState _currentState = new IGameState.Empty();


        public GameStateMachine(IEnumerable<IGameState> states) : this(CreatStates(states)) { }

        public GameStateMachine(Dictionary<Type, IGameState> states) =>
            _states = states;

        public void Enter<IState>() where IState : IGameState
        {
            var typeState = typeof(IState);

            if (_states.TryGetValue(typeState, out var state) == false)
                throw new InvalidOperationException("Trying to enter unregistered game state");

            _currentState.Exit();
            _currentState = state;
            _currentState.Enter();
        }

        private static Dictionary<Type, IGameState> CreatStates(IEnumerable<IGameState> states)
        {
            Dictionary<Type, IGameState> createdState = new Dictionary<Type, IGameState>();

            foreach (var state in states)
                createdState.Add(state.GetType(), state);

            return createdState;
        }
    }
}
