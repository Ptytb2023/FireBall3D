using UnityEngine;
using System.Collections;

using Obstacel.Sequence;
using Structures;
using Obstacel;

namespace Obstaicel.Sequence
{
    public class MoveSequenceTerm : ISequnceTerm
    {
        private readonly FloatRange _duration;
        private readonly IMovement _movment;

        public MoveSequenceTerm(FloatRange duration, IMovement movment)
        {
            _duration = duration;
            _movment = movment;
        }

        public IEnumerator GetSequnceCorutine()
        {
            float enteredTime = Time.time;
            float duration = _duration.Random;
            float speed = _movment.Speed;

            while (Time.time < enteredTime + duration)
            {
                _movment.Move(speed);

                yield return null;
            }
        }
    }
}
