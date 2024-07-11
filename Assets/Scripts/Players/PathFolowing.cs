using DG.Tweening;
using Paths;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

namespace Players
{
    public class PathFolowing
    {
        private readonly Path _path;
        private readonly MovebelPreferenceSo _movebelData;
        private readonly Transform _follower;

        private int _currentIndexPath;

        public PathFolowing(Path path, MovebelPreferenceSo movebelData, Transform follower)
        {
            _path = path;
            _movebelData = movebelData;
            _follower = follower;

            _currentIndexPath = 0;
        }


        public async Task MoveToNextAsync()
        {
            if (_currentIndexPath > _path.Segments.Count)
                _currentIndexPath = 0;

            PathSegment segmentPath = _path.Segments[_currentIndexPath];

            await MoveToPoitns(_follower, segmentPath.Waypoints);
            _currentIndexPath++;
        }

        private async Task MoveToPoitns(Transform follower, IReadOnlyList<Transform> waypoints)
        {
            float durationLookAt = _movebelData.DurationLookAtPoint;
            float durationMove = _movebelData.DurationMoveToPoint;
            float totalDuration = _movebelData.TottalDuration;

            for (int i = 1; i < waypoints.Count; i++)
            {
                Vector3 position = waypoints[i].position;
                position.y = follower.position.y;

                Task lookAt = follower.DOLookAt(position, durationLookAt).
                    AsyncWaitForCompletion();

                Task move = follower.DOMove(position, durationMove).
                    AsyncWaitForCompletion();

                await Task.WhenAll(lookAt, move);
            }
        }
    }
}
