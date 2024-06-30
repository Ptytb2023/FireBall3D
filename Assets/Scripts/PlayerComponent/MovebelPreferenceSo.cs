using UnityEngine;

namespace PlayerComponent
{
    [CreateAssetMenu(fileName = nameof(MovebelPreferenceSo),
        menuName = nameof(ScriptableObject) + "/" + nameof(Pathes) + "/" + nameof(MovebelPreferenceSo),
        order = 51)]
    public class MovebelPreferenceSo : ScriptableObject
    {
        [SerializeField] private float _durationLookAtPoint;
        [SerializeField] private float _durationMovePerPoint;

        public float DurationLookAtPoint => _durationLookAtPoint;
        public float DurationMoveToPoint => _durationMovePerPoint;


        public float TottalDuration => _durationMovePerPoint + _durationLookAtPoint;

    }
}
