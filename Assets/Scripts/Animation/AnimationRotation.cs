using DG.Tweening;
using System;
using TweenStructures;
using UnityEngine;

namespace Animation
{
    [Serializable]
    public class AnimationRotation
    {
        [field: SerializeField] public Vector3TweenData RoationData { get; private set; }


        public void ApplayRoation(Transform transform)
        {
            var toRotation = RoationData.ToValue;
            var duration = RoationData.Duration;
            var easing = RoationData.Easing;

            transform.
                DORotate(toRotation, duration, RotateMode.FastBeyond360).
                SetEase(easing);
        }

    }
}