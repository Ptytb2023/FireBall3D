using System;
using UnityEngine;


using UnityObject = UnityEngine.Object;

namespace Towers.Disassembling
{
    public class TowerDisassembling /*: IDisposable*/
    {
        private Transform _rootTower;
        private readonly Tower _tower;
        private float _stepOfSquntialRotationY;

        public event Action Disassembling;

        public TowerDisassembling(Transform rootTower, Tower tower, float stepOfSquntialRotationY)
        {
            _rootTower = rootTower;
            _tower = tower;
            _stepOfSquntialRotationY = stepOfSquntialRotationY;

            //_tower.CountSegments.Subscribe(OnOverSegments);
        }

        public void TryRemoveBotton()
        {
            if (_tower.CountSegments.Value <= 0)
            {
                Disassembling?.Invoke();
                return;
            }

            SegmentPlatform towerSegment = _tower.GetTowerSegment();

            float scaleY = towerSegment.transform.localScale.y;
            _rootTower.position -= Vector3.up * scaleY;
            _rootTower.rotation = Quaternion.Euler(Vector3.up * _stepOfSquntialRotationY);

            UnityObject.Destroy(towerSegment.gameObject);
        }

        private void OnOverSegments(int value) =>
            Disassembling?.Invoke();

        //public void Dispose() => 
        //    _tower.CountSegments.UnSubscribe(OnOverSegments);
    }
}
