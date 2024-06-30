using DG.Tweening;
using Pathes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlayerComponent
{
    public class MovebelByPath
    {
        private readonly Path _path;
        private readonly MovebelPreferenceSo _movebelData;
        private readonly MonoBehaviour _follower;

        private int _currentIndexPath;

        public MovebelByPath(Path path, MovebelPreferenceSo movebelData, MonoBehaviour follower)
        {
            _path = path;
            _movebelData = movebelData;
            _follower = follower;

            _currentIndexPath = 0;
        }


        public void MoveToNext()
        {
            if (_currentIndexPath > _path.Pathes.Count)
                _currentIndexPath = 0;

            SegmentPath segmentPath = _path.Pathes[_currentIndexPath];

            _follower.StartCoroutine(MoveToPoitns(segmentPath.Points));

            _currentIndexPath++;
        }

        private IEnumerator MoveToPoitns(IReadOnlyList<Transform> waypoints)
        {
            Transform follower = _follower.transform;

            float durationLookAt = _movebelData.DurationLookAtPoint;
            float durationMove = _movebelData.DurationMoveToPoint;
            float totalDuration = _movebelData.TottalDuration;

            for (int i = 0; i < waypoints.Count; i++)
            {
                Vector3 position = waypoints[i].position;
                position.y = follower.position.y;

                follower.DOLookAt(position, durationLookAt).
                    OnComplete(() => follower.DOMove(position, durationMove));

                yield return new WaitForSeconds(totalDuration);
            }
        }
    }
}
