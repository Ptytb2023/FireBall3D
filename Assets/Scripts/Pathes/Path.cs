using Obstacles;
using Pathes.Buildes;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

namespace Pathes
{
    public class Path : MonoBehaviour
    {
        [SerializeField] private SegmentPath[] _segments;

        public IReadOnlyList<SegmentPath> Segments => _segments;

        public void Initialize(IReadOnlyList<PathPlatfromStructure> paltformStructures,
            ObstacleCollisionFeedback feedback, CancellationTokenSource cancellationTokenSource)
        {
            for (int i = 0; i < paltformStructures.Count; i++)
            {
                PathPlatformBuilder builder = _segments[i].PathPlatformBuilder;
                builder.Intialize(paltformStructures[i], feedback, cancellationTokenSource);
            }
        }
    }
}
