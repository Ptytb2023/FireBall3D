using System.Collections.Generic;
using UnityEngine;

namespace Pathes
{
    public class Path : MonoBehaviour
    {
        [SerializeField] private SegmentPath[] pathes;

        public IReadOnlyList<SegmentPath> Pathes => pathes;
    }
}
