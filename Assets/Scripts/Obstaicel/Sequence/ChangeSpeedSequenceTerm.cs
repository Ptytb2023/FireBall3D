using Obstacel;
using Obstacel.Sequence;
using Structures;
using System.Collections;
using UnityEngine;

using Random = UnityEngine.Random;

namespace Sequence
{
    public class ChangeSpeedSequenceTerm : ISequnceTerm
    {
        private const float PositiveChnageSpeedPrecent = 0.5f;

        private readonly IMovement _movement;
        private readonly FloatRange _speed;
        private readonly FloatRange _duration;
        private readonly AnimationCurve _animationCurve;

        public ChangeSpeedSequenceTerm(IMovement movement, FloatRange speed, FloatRange duration, AnimationCurve animationCurve)
        {
            _movement = movement;
            _speed = speed;
            _duration = duration;
            _animationCurve = animationCurve;
        }

        public IEnumerator GetSequnceCorutine()
        {
            float eteredTime = Time.time;
            float duration = _duration.Random;

            float eteredSpeed = _movement.Speed;
            float newSpeed = ChooseSpeed(_speed);


            while (Time.time < eteredTime + duration)
            {
                float elapsedTimePresend = (Time.time - eteredTime) / duration;

                float diferents = newSpeed - eteredSpeed;

                float scaleDiferents = diferents * _animationCurve.Evaluate(elapsedTimePresend);

                float speed = eteredSpeed + scaleDiferents;

                _movement.Move(speed);

                yield return null;
            }
        }

        private float ChooseSpeed(FloatRange speed) =>
            Random.value > PositiveChnageSpeedPrecent ? speed.Random : -speed.Random;
    }
}
