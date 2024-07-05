using Obstacles;
using System;
using Towers.Strucure;
using UnityEngine;

namespace Pathes.Buildes
{
    [Serializable]
    public struct PathPlatfromStructure
    {
        [field: SerializeField] public TowerStructuresSo TowerStructures { get; private set; }
        [field: SerializeField] public Obstacle[] ObstaclesPrefab { get; private set; }
    }
}
