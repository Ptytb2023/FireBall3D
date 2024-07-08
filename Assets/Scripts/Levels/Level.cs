using Levels.Generation;
using SceneLoading;
using System;
using UnityEngine;

namespace Levels
{
    [Serializable]
    public struct Level
    {
        [field: SerializeField] public Scene LocationScene { get; private set; }
        [field: SerializeField] public PathStructuresSo PathStructuresSo { get; private set; }
    }
}
