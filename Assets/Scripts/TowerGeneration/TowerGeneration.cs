using Animation;
using System;
using System.Collections;
using System.Linq;
using UnityEngine;
using UnityObject = UnityEngine.Object;

namespace Generation
{
    public class TowerGeneration : MonoBehaviour
    {
        [SerializeField] private Transform _pointTower;
        [SerializeField] private AnimationRotation _animation;
        [SerializeField] private UnityObject _towerFactory;

        private Tower _tower;

        private ITowerFactory TowerFactory => _towerFactory as ITowerFactory;

        [ContextMenu(nameof(Generation))]
        private void Generation()
        {

            _tower = TowerFactory.Creat(_pointTower);
            _animation.ApplayRoation(_pointTower);

            float secondDelay = _animation.RoationData.Duration / (float)_tower.Segments.Count();

            StartCoroutine(SwithebleSegmentPlatformByDelay(secondDelay));
        }


        private IEnumerator SwithebleSegmentPlatformByDelay(float second)
        {
            WaitForSeconds delay = new WaitForSeconds(second);

            foreach (var segment in _tower.Segments)
            {
                segment.gameObject.SetActive(true);
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