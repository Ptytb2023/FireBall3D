using DG.Tweening;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TweenStructures;
using UnityEngine;

namespace Tweening
{
    [CreateAssetMenu(fileName = nameof(LocalMoveTween),
        menuName = nameof(ScriptableObject) + "/" + nameof(Tweening) + "/" + nameof(LocalMoveTween),
        order = 51)]
    public class LocalMoveTween : ScriptableObject, IAwaitableTweenAnimation, ITweenAnimation
    {
        [SerializeField] private Vector3TweenData _move;

      

        void ITweenAnimation.ApplyTo(Transform transform)
        {
            ApplyToInternal(transform);
        }

        public async Task ApplyTo(Transform transform)
        {
            await ApplyToInternal(transform).AsyncWaitForCompletion();
        }

        private Tween ApplyToInternal(Transform transform)
        {
            return transform.
                DOLocalMove(_move.ToValue, _move.Duration).
                SetEase(_move.Easing);
        }
    }
}
