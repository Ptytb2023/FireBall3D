using UnityEngine;

namespace Physics
{
    [CreateAssetMenu(fileName = nameof(DirectionBouncedPreferenceSo),
        menuName = nameof(ScriptableObject) + "/" + nameof(Physics) + "/" + nameof(DirectionBouncedPreferenceSo),
        order = 51)]
    public class DirectionBouncedPreferenceSo : ScriptableObject
    {
        [SerializeField] private DirectionlBouncedPreferences _directionlBouncedPreferences;

        public DirectionlBouncedPreferences DirectionlBouncedPreferences => _directionlBouncedPreferences;
    }
}
