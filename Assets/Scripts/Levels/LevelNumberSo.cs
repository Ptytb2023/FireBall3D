using UnityEngine;

namespace Levels
{
    [CreateAssetMenu(fileName = nameof(LevelNumberSo),
    menuName = nameof(ScriptableObject) + "/" + nameof(Levels) + "/" + nameof(LevelNumberSo),
    order = 51)]
    public class LevelNumberSo : ScriptableObject, ILevelNumberSo
    {
        public int Value { get; set; } = 1;
    }
}
