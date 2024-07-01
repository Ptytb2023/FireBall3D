using System;
using System.Collections;
using System.Linq;
using UnityEngine;

using Animation;
using UnityObject = UnityEngine.Object;

namespace Towers.Generation
{
    public class TowerGeneration : MonoBehaviour, ITowerSwichSegmentCallback
    {
        [SerializeField] private Transform _pointTower;
        [SerializeField] private AnimationRotation _animation;
        [SerializeField] private UnityObject _towerFactory;

        private Tower _tower;

        public event Action<int> SwichSegment;

        private ITowerFactory TowerFactory => _towerFactory as ITowerFactory;

        [ContextMenu(nameof(Generation))]
        public Tower Generation()
        {
            _tower = TowerFactory.Creat(_pointTower);
            _animation.ApplayRoation(_pointTower);

            float secondDelay = _animation.RoationData.Duration / (float)_tower.Segments.Count();

            StartCoroutine(SwithebleSegmentPlatformByDelay(secondDelay));

            return _tower;
        }


        private IEnumerator SwithebleSegmentPlatformByDelay(float second)
        {
            WaitForSeconds delay = new WaitForSeconds(second);

            var segments = _tower.Segments;

            for (int i = 0; i < segments.Count; i++)
            {
                segments[i].gameObject.SetActive(true);

                SwichSegment?.Invoke(i + 1);

                yield return delay;
            }

        }

        private void OnValidate()
        {
            if (_towerFactory is not ITowerFactory)
            {
                _towerFactory = null;
                throw new InvalidOperationException($"Tower Factory should be derived from {nameof(ITowerFactory)}");
            }
        }

    }
}