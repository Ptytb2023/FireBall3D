using System;
using UnityRandom = UnityEngine.Random;

namespace Structures
{
    [Serializable]
    public class FloatRange : Range<float>
    {
        public float Random => UnityRandom.Range(Min, Max);

    }
}