using DG.Tweening;
using TweenStructures;
using UnityEngine;

namespace Tweening
{
    [CreateAssetMenu(fileName = nameof(FastRotationTweenSo),
        menuName = nameof(ScriptableObject) + "/" + nameof(Tweening) + "/" + nameof(FastRotationTweenSo),
        order = 51)]
    public class FastRotationTweenSo : ScriptableObject, ITweenAnimation
    {
        [SerializeField] private Vector3TweenData _rotation;

        public void ApplyTo(Transform transform) => 
            ApplyTo(transform, _rotation);

        public void ApplyTo(Transform transform, Vector3TweenData rotation) => 
            transform.
                DORotate(rotation.ToValue, rotation.Duration, RotateMode.FastBeyond360).
                SetEase(rotation.Easing);
    }
}
