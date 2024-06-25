using System;
using UnityEngine;

namespace TweenStructures
{

    [Serializable]
    public class Vector3RangeTweenData : RangeTweenData<Vector3> { }

    [Serializable]
    public class Vector2RangeTweenData : RangeTweenData<Vector2> { }


    [Serializable]
    public class RangeTweenData<T> : TweenData<T>
    {
        [field: SerializeField] public T FromValue { get; private set; }
    }
}
