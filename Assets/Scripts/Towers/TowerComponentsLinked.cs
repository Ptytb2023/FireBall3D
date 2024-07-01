using Shooting.Pool;
using Towers.Disassembling;
using Towers.Effects;
using Towers.Generation;
using UI.Towers;
using UnityEngine;

namespace Towers
{
    public class TowerComponentsLinked : MonoBehaviour
    {
        [SerializeField] private float _stepRoationY = 4f;

        [SerializeField] private Transform _towerRoot;
        [SerializeField] private TowerGeneration _generation;
        [SerializeField] private RestoreProjectilePoolTriget _progetileHitTrigger;

        [Space]
        [SerializeField] private TowerSegmentsCountLeftText _towerSegmentText;
        [SerializeField] private TowerAudio _towerAudio;

        private TowerDisassembling _disassembling;
        private Tower _tower;

        private void Awake()
        {
            Prepare();
        }

        [ContextMenu(nameof(Prepare))]
        public void Prepare()
        {
            _tower = _generation.Generation();
            _disassembling = new TowerDisassembling(_towerRoot, _tower, _stepRoationY);

            _progetileHitTrigger.ProjectileReturn += _disassembling.TryRemoveBotton;
            _disassembling.Disassembling += OnDisassemblingTower;

            _generation.SwichSegment += _towerSegmentText.UpdateTextValue;

            _tower.CountSegments.Subscribe(_towerSegmentText.UpdateTextValue);
            _tower.CountSegments.Subscribe(_towerAudio.PlaySound);
        }



        private void OnDisassemblingTower()
        {
            Destroy(gameObject);
        }

        private void OnDisable()
        {
            _progetileHitTrigger.ProjectileReturn -= _disassembling.TryRemoveBotton;
            _disassembling.Disassembling -= OnDisassemblingTower;

            _tower.CountSegments.UnSubscribe(_towerAudio.PlaySound);
            _tower.CountSegments.UnSubscribe(_towerSegmentText.UpdateTextValue);

            _generation.SwichSegment -= _towerSegmentText.UpdateTextValue;


            Destroy(_progetileHitTrigger.gameObject);
            Destroy(_generation.gameObject);
            Destroy(_towerRoot.gameObject);
        }
    }
}
