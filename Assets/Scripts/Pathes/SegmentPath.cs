using Pathes.Buildes;
using System;
using System.Collections.Generic;
using UnityEngine;


namespace Pathes
{
    [Serializable]
    public class SegmentPath
    {
        [field: SerializeField] public PathPlatformBuilder PathPlatformBuilder { get; private set; }

        [SerializeField] private Transform[] _points = Array.Empty<Transform>();

        public IReadOnlyList<Transform> Waypoints => _points;
    }
}
