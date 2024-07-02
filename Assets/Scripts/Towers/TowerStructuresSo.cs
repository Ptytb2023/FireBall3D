using System;
using UnityEngine;

namespace Towers.Strucure
{
    [CreateAssetMenu(
        fileName = nameof(TowerStructuresSo),
        menuName = nameof(ScriptableObject) + "/" + nameof(Tower) + "/" + nameof(TowerStructuresSo),
        order = 51)]
    public class TowerStructuresSo : ScriptableObject
    {
        [SerializeField] private SegmentPlatform _segmentPrefab;
        [SerializeField][Min(0)] private int _countSpawn;
        [SerializeField] private float _spawnTimeSegmentMillisecond;
        [SerializeField] private float _stepRotationYByDisassembling;

        [SerializeField] private Material[] _materials = Array.Empty<Material>();


        public SegmentPlatform SegmentPrefab => _segmentPrefab;
        public float SpawnTimeSegmentMillisecond => _spawnTimeSegmentMillisecond;
        public int SegmentCount => _countSpawn;
        public float StepRotationYByDisassembling => _stepRotationYByDisassembling;

        public Material GetMaterial(int nuberOfInstance)
        {
            int index = nuberOfInstance % _materials.Length;

            return _materials[index];
        }

    }

}