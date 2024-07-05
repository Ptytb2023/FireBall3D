using System;
using System.Threading.Tasks;
using UnityEngine;

using ReactiveProperties;
using Shooting.Pool;
using Towers;
using Towers.Disassembling;
using Towers.Effects;
using Towers.Generation;
using Towers.Strucure;
using Tweening;
using UI.Towers;

namespace Pathes.Buildes
{
    public class PathTowerBuilder : MonoBehaviour
    {
        [SerializeField] private Transform _towerRoot;

        [Header("Effects")]
        [SerializeField] private TowerAudio _audio;

        [Header("Linked Components")]
        [SerializeField] private FastRotationTweenSo _spawnAnimation;
        [SerializeField] private TowerSegmentsCountLeftText _segmentsCountLeft;
        [SerializeField] private RestoreProjectilePoolTriget _projectileHitTriger;

        private Action _unsubscribe;
        private TowerStructuresSo _structures;


        public void Initialize(TowerStructuresSo structures)
        {
            _structures = structures;
        }

        public async Task<TowerDisassembling> BuildAsync(ProjectilePool pool)
        {
            _spawnAnimation.ApplyTo(_towerRoot);
            _projectileHitTriger.Initialisation(pool);

            TowerGeneration generation = new TowerGeneration(_structures);
            generation.CreatSegment += _segmentsCountLeft.UpdateTextValue;

            Tower tower = await generation.CreatAsync(_towerRoot);

            float stepRotationYByDisassembling = _structures.StepRotationYByDisassembling;
            TowerDisassembling disassembling = new TowerDisassembling(_towerRoot, tower, stepRotationYByDisassembling);

            SubscribeComponents(generation, tower, disassembling);

            return disassembling;
        }

        private void SubscribeComponents(TowerGeneration generation, Tower tower, TowerDisassembling disassembling)
        {
            _projectileHitTriger.ProjectileReturn += disassembling.TryRemoveBotton;

            IReadOnlyReactiveProperty<int> segmentCount = tower.CountSegments;

            segmentCount.SubscribeAndUpdate(_segmentsCountLeft.UpdateTextValue);
            segmentCount.SubscribeAndUpdate(_audio.PlaySound);


            _unsubscribe = () =>
            {
                generation.Dispose();

                generation.CreatSegment -= _segmentsCountLeft.UpdateTextValue;
                _projectileHitTriger.ProjectileReturn -= disassembling.TryRemoveBotton;

                segmentCount.UnSubscribe(_segmentsCountLeft.UpdateTextValue);
                segmentCount.UnSubscribe(_audio.PlaySound);
            };
        }

        private void OnDisable()
        {
            _unsubscribe?.Invoke();
        }
    }
}
