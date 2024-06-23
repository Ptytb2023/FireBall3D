using TweenStructures;
using UnityEngine;
using DG.Tweening;

public class DropDownAnimation : MonoBehaviour
{
    [SerializeField] private Vector2RangeTweenData _rangeTweenData;
    [SerializeField] private GameObject _actionRoot;
    [SerializeField] private float _delayBetweenDropDownObject;

    private RectTransform[] _dropDownList;
    private bool _isActive;

    private void Start()
    {
        _dropDownList = _actionRoot.GetComponentsInChildren<RectTransform>();
        _isActive = true;

        ApplayDropDawn(_rangeTweenData, _dropDownList, _isActive);
    }

    public void OnButtonClick()
    {
        _isActive = !_isActive;

        ApplayDropDawn(_rangeTweenData, _dropDownList, _isActive);
    }

    private void ApplayDropDawn(Vector2RangeTweenData tweenData, RectTransform[] dropDownList, bool isFrom)
    {
        float delay = 0.0f;

        foreach (RectTransform dropDown in dropDownList)
        {
            Vector3 sizeDelta = isFrom ? tweenData.FromValue : tweenData.ToValue;

            dropDown.
                DOSizeDelta(sizeDelta, tweenData.Duration).
                SetDelay(delay).
                SetEase(tweenData.Easing);

            delay += _delayBetweenDropDownObject;
        }
    }
}
