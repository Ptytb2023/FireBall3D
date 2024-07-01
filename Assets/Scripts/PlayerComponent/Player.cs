using UnityEngine;
using Shooting;
using Inputs;
using Characters;
using Pathes;
using Shooting.Pool;

namespace PlayerComponent
{
    public class Player : MonoBehaviour
    {
        [Header("Input")]
        [SerializeField] private InputWeapon _weaponInput;

        [Header("Visual")]
        [SerializeField] private Character _caharcer;

        [Header("Setting")]
        [SerializeField] private MovebelPreferenceSo _movebelPreferenceSo;
        [SerializeField] private ShootingPreferenceSo _shootingPreference;
        [SerializeField] private Path _path;
        
        [Space]
        [SerializeField] private ProjectilePool _pool;


        private MovebelByPath _movebel;
        private FireRate _fireRate;
        private Weapon _weapon;

        private void Awake()
        {
            _weapon = new Weapon(_caharcer.ShootPoint, _pool, _shootingPreference.speedBullet);
            _fireRate = new FireRate(_shootingPreference.FireRate);

            _movebel = new MovebelByPath(_path, _movebelPreferenceSo, this);
        }

        private void OnEnable()
        {
            _weaponInput.Hold += TryAction;
        }

        private void OnDisable()
        {
            _weaponInput.Hold -= TryAction;
        }

        private void TryAction() =>
            _fireRate.TryShoot(_weapon);

        [ContextMenu(nameof(Move))]
        public void Move() =>
            _movebel.MoveToNext();
    }
}
