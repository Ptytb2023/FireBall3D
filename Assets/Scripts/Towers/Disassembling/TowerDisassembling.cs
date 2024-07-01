﻿using System;
using UnityEngine;


using UnityObject = UnityEngine.Object;

namespace Towers.Disassembling
{
    public class TowerDisassembling
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
        }

        public void TryRemoveBotton()
        {
            if (_tower.CountElements <= 0)
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
    }
}
