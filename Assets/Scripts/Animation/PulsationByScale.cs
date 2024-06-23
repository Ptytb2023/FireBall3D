using System.Collections;
using UnityEngine;

public class PulsationByScale : MonoBehaviour
{

    private IEnumerator PlayAnimationScale(Transform transform, Vector3 to, float duration, AnimationCurve animationCurve)
    {
        float enterTime = Time.time;

        Vector3 eterScale = transform.localScale;

        while (enterTime < duration + Time.time)
        {
            float elapsedTimePrecend = (Time.time - enterTime) / duration;

            Vector3 diffrence = to - eterScale;

            Vector3 newScale = animationCurve.Evaluate(elapsedTimePrecend) * diffrence;

            transform.localScale = newScale;

            yield return null;
        }

    }
}
