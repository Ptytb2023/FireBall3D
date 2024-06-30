using UnityEngine;
using Shooting;
using Inputs;
using Characters;
using Pathes;

namespace PlayerComponent
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private InputWeapon _weaponInput;

        [SerializeField] private Character _caharcer;
        [SerializeField] private ShootingPreferenceSo _hootingPreferenceSo;

        [SerializeField] private MovebelPreferenceSo _movebelPreferenceSo;
        [SerializeField] private Path _path;


        private MovebelByPath _movebel;
        private FireRate _fireRate;
        private Weapon _weapon;

        private void Awake()
        {
            _weapon = _hootingPreferenceSo.GetWeapon(_caharcer.ShootPoint);
            _fireRate = _hootingPreferenceSo.GetFireRate();

            _movebel = new MovebelByPath(_path, _movebelPreferenceSo, this);
        }

        private void OnEnable()
        {
            _weaponInput.Hold += TryAction;
        }

        private void OnDisable()
        {
            _weaponInput.Begin -= TryAction;
        }

        private void TryAction() =>
            _fireRate.TryShoot(_weapon);

        [ContextMenu(nameof(Move))]
        public void Move() =>
            _movebel.MoveToNext();
    }
}
