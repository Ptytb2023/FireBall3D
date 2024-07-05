using System.Collections.Generic;
using UnityEngine;

namespace Pathes
{
    public class Path : MonoBehaviour
    {
        [SerializeField] private SegmentPath[] _segments;

        public IReadOnlyList<SegmentPath> Segments => _segments;
    }
}
