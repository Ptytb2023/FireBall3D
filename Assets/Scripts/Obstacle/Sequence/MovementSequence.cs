using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Coroutines;
using Obstacle.Sequence;

namespace Obstaicel.Sequence
{
    public class MovementSequence
    {
        private readonly IReadOnlyList<ISequnceTerm> _terms;
        private readonly CoroutinesExecutor _coroutinesExecutor;

        private int _currentTermIndex;
        private Coroutine _executableSequence;

        public MovementSequence(IReadOnlyList<ISequnceTerm> terms, CoroutinesExecutor coroutinesExecutor)
        {
            if (terms is null || coroutinesExecutor is null || terms.Count == 0)
                throw new ArgumentException();

            _coroutinesExecutor = coroutinesExecutor;
            _terms = terms;
            _currentTermIndex = 0;
        }

        public void StartProccesing() =>
            _executableSequence = _coroutinesExecutor.Start(ChangeBetweenStates());

        public void StopProccesing() =>
            _coroutinesExecutor.Stop(_executableSequence);

        public IEnumerator ChangeBetweenStates()
        {
            while (true)
            {
                IEnumerator termsCorutine = _terms[_currentTermIndex].GetSequnceCorutine();

                yield return _coroutinesExecutor.Start(termsCorutine);

                _currentTermIndex = GetNextTermIndex(_currentTermIndex);
            }
        }

        private int GetNextTermIndex(int currentIndex) =>
            (currentIndex + 1) % _terms.Count;
    }
}
