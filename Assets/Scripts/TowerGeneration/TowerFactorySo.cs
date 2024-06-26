using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEditor;
using UnityEngine;

namespace Generation
{
    [CreateAssetMenu(
        fileName = nameof(TowerFactorySo),
        menuName = nameof(ScriptableObject) + "/" + nameof(Tower) + "/" + nameof(TowerFactorySo),
        order = 51)]
    public class TowerFactorySo : ScriptableObject, IAsyncTowerFactory
    {
        [SerializeField] private SegmentPlatform _segmentPrefab;
        [SerializeField][Min(0)] private int _countSpawn;
        [SerializeField][Min(0)] private float _secondBetweenSpawnPlatform;
        [SerializeField] private Material[] _materials = Array.Empty<Material>();

        private float StepOfSquntialRotationY => 360 / _countSpawn;


       
        public async Task<Tower> CreatAsync(Transform tower)
        {
            Vector3 postionSpawn = tower.position;
            Quaternion roationPlatform = Quaternion.identity;

            Queue<SegmentPlatform> platforms = new Queue<SegmentPlatform>(_countSpawn);


            for (int i = 0; i < _countSpawn; i++)
            {
                var platform = Instantiate(_segmentPrefab, postionSpawn, roationPlatform, tower);

                platforms.Enqueue(platform);

                postionSpawn = NextPostionAfter(platform, _segmentPrefab);

                roationPlatform = GetNextRoation(platform.transform.rotation);

                await ApplayDeleay(_secondBetweenSpawnPlatform);
            }

            return new Tower(platforms);

        }

        private async Task ApplayDeleay(float second)
        {
            TimeSpan timeSpawn = TimeSpan.FromSeconds(second);
            await Task.Delay(timeSpawn);
        }

        private Quaternion GetNextRoation(Quaternion lastRoation)
        {
            Vector3 nexRotation = StepOfSquntialRotationY * Vector3.up + lastRoation.eulerAngles;

            return Quaternion.Euler(nexRotation);
        }


        private Vector3 NextPostionAfter(SegmentPlatform lastPlatform, SegmentPlatform ToPlatform)
        {
            float lastSizeYPlatform = GetBoundsExtentsYByMesh(lastPlatform);
            float sizeYToPlatform = GetBoundsExtentsYByMesh(ToPlatform);


            Vector3 lastPlatformPosition = lastPlatform.transform.position;
            Vector3 lastPlatformBounds = lastSizeYPlatform * Vector3.up;
            Vector3 ToPlatformBounds = sizeYToPlatform * Vector3.up;

            return lastPlatformPosition + lastPlatformBounds + ToPlatformBounds;
        }


        private float GetBoundsExtentsYByMesh(SegmentPlatform segmentPlatform)
        {
            Mesh mesh = segmentPlatform.GetComponent<Mesh>();
            return mesh.bounds.extents.y;
        }
    }

}