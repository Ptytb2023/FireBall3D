using System;
using System.Collections;
using Structures;
using Coroutines;
using UnityEngine;

namespace Physics
{
    public class DirectionalBouced
    {
        private readonly Transform _bounced;
        private readonly CoroutinesExecutor _executor;
        private readonly DirectionlBouncedPreferences _bouncedPreferences;

        public DirectionalBouced(Transform bounced, CoroutinesExecutor executor, DirectionlBouncedPreferences bouncedPreferences)
        {
            _bounced = bounced;
            _executor = executor;
            _bouncedPreferences = bouncedPreferences;
        }


        public void BouncedTo(Vector3 target,Vector3 startPostion)=>
            _executor.Start(InterpolatePostion(target,startPostion));

        private IEnumerator InterpolatePostion(Vector3 target, Vector3 startPostion)
        {
            UnityTime time = new UnityTime();

            float height = _bouncedPreferences.Height;
            AnimationCurve trajectory = _bouncedPreferences.Trajecroty;

            time.Start(_bouncedPreferences.Duration);

            while (time.IsTimeUp)
            {
                float t = time.ElapsedTimePresent;

                Vector3 newPostion = Vector3.Lerp(startPostion, target, t);
                newPostion += Vector3.up * trajectory.Evaluate(t) * height;

                _bounced.position = newPostion;
                yield return null;
            }

        }
    }

    [Serializable]
    public class DirectionlBouncedPreferences
    {
        public DirectionlBouncedPreferences(float duration, float height, AnimationCurve trajecroty)
        {
            Duration = duration;
            Height = height;
            Trajecroty = trajecroty;
        }

        [field: SerializeField] public float Duration { get; private set; }
        [field: SerializeField] public float Height { get; private set; }
        [field: SerializeField] public AnimationCurve Trajecroty { get; private set; }


    }
}
