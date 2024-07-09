using UnityEngine;

namespace Menu.Levels
{
    [CreateAssetMenu(fileName = nameof(LevelsColorSo),
        menuName = nameof(ScriptableObject) + "/" + nameof(Menu.Levels) + "/" + nameof(LevelsColorSo),
        order = 51)]
    public class LevelsColorSo : ScriptableObject
    {
        [field: SerializeField] public Color PassedLevels { get; private set; } = Color.green;
        [field: SerializeField] public Color NextLevels { get; private set; } = Color.red;

    }
}
