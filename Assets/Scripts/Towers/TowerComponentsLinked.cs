using Shooting.Pool;
using Towers.Disassembling;
using Towers.Generation;
using UnityEngine;

namespace Towers
{
    public class TowerComponentsLinked : MonoBehaviour
    {
        [SerializeField] private float _stepRoationY = 4f;

        [SerializeField] private Transform _towerRoot;
        [SerializeField] private TowerGeneration _generation;
        [SerializeField] private RestoreProjectilePoolTriget _progetileHitTrigger;

        private TowerDisassembling _disassembling;
        private Tower _tower;

        [ContextMenu(nameof(Prepare))]
        public void Prepare()
        {
            _tower = _generation.Generation();
            _disassembling = new TowerDisassembling(_towerRoot, _tower, _stepRoationY);

            _progetileHitTrigger.ProjectileReturn += _disassembling.RemoveBotton;
        }

        private void OnDisable()
        {
            if (_disassembling is not null)
                _progetileHitTrigger.ProjectileReturn -= _disassembling.RemoveBotton;

        }
    }
}
