using Obstacles;
using System;
using Towers.Strucure;
using UnityEngine;

namespace Pathes.Buildes
{
    [Serializable]
    public class PathPaltform
    {
        [field: SerializeField] public TowerStructuresSo TowerStructures { get; private set; }
        [field: SerializeField] public Obstacle[] ObstaclesPrefab { get; private set; }
    }
}
