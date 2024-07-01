using System;
using System.Collections.Generic;
using UnityEngine;

namespace Towers.Generation
{
    [CreateAssetMenu(
        fileName = nameof(TowerFactorySo),
        menuName = nameof(ScriptableObject) + "/" + nameof(Tower) + "/" + nameof(TowerFactorySo),
        order = 51)]
    public class TowerFactorySo : ScriptableObject, ITowerFactory
    {
        [SerializeField] private SegmentPlatform _segmentPrefab;
        [SerializeField][Min(0)] private int _countSpawn;

        [SerializeField] private Material[] _materials = Array.Empty<Material>();
        [SerializeField] private float _stepOfSquntialRotationY = 4f;


        private float StepOfSquntialRotationY => 360 / _countSpawn;



        public Tower Creat(Transform tower)
        {
            Vector3 postionSpawn = tower.position;
            Quaternion rotation = GetNexRotation(Quaternion.Euler(Vector3.zero));

            Queue<SegmentPlatform> platforms = new Queue<SegmentPlatform>(_countSpawn);

            for (int i = 0; i < _countSpawn; i++)
            {
                SegmentPlatform platform = CreatPlatform(tower, postionSpawn, rotation, i);
                platform.gameObject.SetActive(false);

                rotation = GetNexRotation(platform.transform.rotation);
                postionSpawn = NextPostionAfter(platform, _segmentPrefab);

                platforms.Enqueue(platform);
            }

            return new Tower(platforms);
        }

        private SegmentPlatform CreatPlatform(Transform tower, Vector3 postionSpawn, Quaternion rotation, int nuberOfInstancei)
        {
            var platform = Instantiate(_segmentPrefab, postionSpawn, rotation, tower);
            platform.SetMaterial(GetMaterial(nuberOfInstancei));

            return platform;
        }


        private Material GetMaterial(int nuberOfInstance)
        {
            int index = nuberOfInstance % _materials.Length;

            return _materials[index];
        }

        private Quaternion GetNexRotation(Quaternion lastRotation)
        {
            Vector3 nextRotation = _stepOfSquntialRotationY * Vector3.up + lastRotation.eulerAngles;
            return Quaternion.Euler(nextRotation);
        }

        private Vector3 NextPostionAfter(SegmentPlatform lastPlatform, SegmentPlatform ToPlatform)
        {
            ////float lastSizeYPlatform = GetBoundsExtentsYByMesh(lastPlatform);
            ////float sizeYToPlatform = GetBoundsExtentsYByMesh(ToPlatform);      
            //float lastSizeYPlatform = lastPlatform.transform.localScale.y;
            //float sizeYToPlatform = ToPlatform.transform.localScale.y;


            //Vector3 lastPlatformPosition = lastPlatform.transform.position;
            //Vector3 lastPlatformBounds = lastSizeYPlatform  * Vector3.up;
            //Vector3 ToPlatformBounds = sizeYToPlatform  * Vector3.up;

            //return lastPlatformPosition + lastPlatformBounds + ToPlatformBounds;


            Vector3 currentPostion = lastPlatform.transform.position;
            float segmentHight = ToPlatform.transform.localScale.y;

            return currentPostion + segmentHight * Vector3.up;

        }


        private float GetBoundsExtentsYByMesh(SegmentPlatform segmentPlatform)
        {
            MeshRenderer mesh = segmentPlatform.GetComponent<MeshRenderer>();
            Vector3 scale = segmentPlatform.transform.localScale;

            return mesh.bounds.size.y * scale.y;
        }
    }

}