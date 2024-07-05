using UnityEngine;
using Shooting;
using Inputs;
using Characters;
using Pathes;
using Shooting.Pool;

namespace Players
{
    public class Player : MonoBehaviour
    {
        [Header("Input")]
        [SerializeField] private PlayerInputHandler _weaponInput;

        [Header("Visual")]
        [SerializeField] private CharacterContainerSo _caharcerContainer;

        [Header("Setting")]

        [SerializeField] private ShootingPreferenceSo _shootingPreference;

        [Space]
        [SerializeField] private ProjectilePool _pool;


        private FireRate _fireRate;
        private Weapon _weapon;

        private void Start()
        {
            Character character = _caharcerContainer.Creat(transform);

            _weapon = new Weapon(character.ShootPoint, _pool, _shootingPreference.speedBullet);
            _fireRate = new FireRate(_shootingPreference.FireRate);
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

    }
}
