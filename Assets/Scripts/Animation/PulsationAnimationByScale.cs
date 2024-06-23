using UnityEngine;
using DG.Tweening;
using TweenStructures;

public class PulsationAnimationByScale : MonoBehaviour
{
    [SerializeField] private Vector3TweenData _tweenData;
   

    private void Start() =>
        ApplyPulsation(_tweenData);


    private void ApplyPulsation(Vector3TweenData tweenData)
    {
        transform.
            DOScale(tweenData.ToValue, tweenData.Duration).
            SetEase(tweenData.Easing).
            SetLoops(-1, LoopType.Yoyo);
    }

    #region Old
    //[SerializeField] private Ease _ease;
    //[SerializeField] private Vector3 _toScale;

    //[SerializeField][Min(0.0f)] private float _duration;

    //private IEnumerator PlayLoopingAnimationScale(Transform transform, Vector3 to, float duration, AnimationCurve animationCurve)
    //{
    //    Vector3 from = transform.localScale;
    //    Vector3 newScale = from;

    //    while (enabled)
    //    {
    //        newScale = newScale.Swap(from, to);

    //        yield return StartCoroutine(PlayAnimationScale(transform, newScale, duration, animationCurve));
    //    }
    //}

    //private IEnumerator PlayAnimationScale(Transform transform, Vector3 to, float duration, AnimationCurve animationCurve)
    //{
    //    float enterTime = Time.time;

    //    Vector3 initialSize = transform.localScale;

    //    while (enterTime > Time.time - duration)
    //    {
    //        float elapsedTimePrecend = (Time.time - enterTime) / duration;

    //        transform.localScale = initialSize.GetProjectByCurve(to, animationCurve, elapsedTimePrecend);

    //        yield return null;
    //    }

    //}
    #endregion

}
