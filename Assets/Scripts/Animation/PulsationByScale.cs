using UnityEngine;
using System.Collections;
using Extension;

public class PulsationByScale : MonoBehaviour
{
    [SerializeField] private AnimationCurve _animationCurve;
    [SerializeField] private Vector3 _toScale;

    [SerializeField][Min(0.0f)] private float _duration;


    private void Start() =>
        StartCoroutine(PlayLoopAnimationScale(transform, _toScale, _duration, _animationCurve));

    private IEnumerator PlayLoopAnimationScale(Transform transform, Vector3 to, float duration, AnimationCurve animationCurve)
    {
        Vector3 from = transform.localScale;
        Vector3 newScale = from;

        while (enabled)
        {
            newScale = newScale.Swap(from, to);

            yield return StartCoroutine(PlayAnimationScale(transform, newScale, duration, animationCurve));
        }
    }

    private IEnumerator PlayAnimationScale(Transform transform, Vector3 to, float duration, AnimationCurve animationCurve)
    {
        float enterTime = Time.time;

        Vector3 initialSize = transform.localScale;

        while (enterTime > Time.time - duration)
        {
            float elapsedTimePrecend = (Time.time - enterTime) / duration;

            transform.localScale = initialSize.GetProjectByCurve(to, animationCurve, elapsedTimePrecend);

            yield return null;
        }

    }

}
