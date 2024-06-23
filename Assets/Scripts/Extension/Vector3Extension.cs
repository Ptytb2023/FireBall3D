using System;
using UnityEngine;

namespace Extension
{
    public static class Vector3Extension
    {

        public static Vector3 Swap(this Vector3 origin, Vector3 valueOne, Vector3 valueTwo)
        {
            if (origin == null)
                throw new ArgumentNullException();

            if (origin == valueOne)
                return valueTwo;
            else if (origin == valueTwo)
                return valueOne;

            throw new ArgumentException();
        }

        public static Vector3 GetProjectByCurve(this Vector3 from, Vector3 to, AnimationCurve animationCurve, float time)
        {
            Vector3 diffrence = to - from;
            return animationCurve.Evaluate(time) * diffrence + from;
        }

    }
}