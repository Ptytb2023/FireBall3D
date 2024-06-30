using System;
using System.Collections.Generic;
using UnityEngine;


namespace Pathes
{
    [Serializable]
    public class SegmentPath 
    {
        [SerializeField] private Transform[] _points = Array.Empty<Transform>();

        public IReadOnlyList<Transform> Points => _points;
    }
}
