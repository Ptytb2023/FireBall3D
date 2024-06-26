using System;
using UnityEngine;
using UnityObject = UnityEngine.Object;

namespace Generation
{
    public class TowerGeneration : MonoBehaviour
    {
        [SerializeField] private UnityObject _towerFactory;

        private IAsyncTowerFactory TowerFactory => _towerFactory as IAsyncTowerFactory;


        private void OnValidate()
        {
            if ( _towerFactory is not IAsyncTowerFactory)
            {
                _towerFactory = null;
                throw new InvalidOperationException($"Tower Factory should be derived from {nameof(IAsyncTowerFactory)}");
            }
        }

    }
}