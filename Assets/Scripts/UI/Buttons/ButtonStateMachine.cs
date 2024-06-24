using StateMachine;
using System;
using UnityEngine;

namespace UI.Buttons
{
    public class ButtonStateMachine : MonoBehaviour
    {
        [SerializeField] private MonoState[] _monoStates = Array.Empty<MonoState>();

        private int _currentIndex;


        private void Start()
        {
            Initialize();
        }


        public void ChangeOnNextState()
        {
           _currentIndex = GetNextIndexState(_currentIndex);
            _monoStates[_currentIndex].Enter();
        }

        private void Initialize()
        {
            if (_monoStates.Length == 0)
                throw new InvalidOperationException("State should be initialize");

            _currentIndex = 0;
            _monoStates[_currentIndex].Enter();
        }

        private int GetNextIndexState(int currentIndex)
        {
            return (_currentIndex + 1) % _monoStates.Length;
        }
    }

}
