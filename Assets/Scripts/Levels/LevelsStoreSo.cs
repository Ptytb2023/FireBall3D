using System;
using System.Collections.Generic;
using UnityEngine;

namespace Levels
{
    [CreateAssetMenu(fileName = nameof(LevelsStoreSo),
    menuName = nameof(ScriptableObject) + "/" + nameof(Levels) + "/" + nameof(LevelsStoreSo),
    order = 51)]
    public class LevelsStoreSo : ScriptableObject, ILevelsStoreSo
    {
        [SerializeField] private Level[] _levels = Array.Empty<Level>();

        public IReadOnlyList<Level> Levles => _levels;
    }
}
