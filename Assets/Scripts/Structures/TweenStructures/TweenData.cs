using System;
using DG.Tweening;
using UnityEngine;

namespace TweenStructures
{

    [Serializable]
    public class Vector3TweenData : TweenData<Vector3> { }

    [Serializable]
    public class Vector2TweenData : TweenData<Vector2> { }


    [Serializable]
    public class TweenData<T>
    {

        [field: SerializeField] public T ToValue { get; private set; }
        [field: SerializeField] public float Duration { get; private set; }
        [field: SerializeField] public Ease Easing { get; private set; }
    }
}