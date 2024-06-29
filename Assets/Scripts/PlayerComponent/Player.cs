using UnityEngine;
using Shooting;
using Inputs;
using Characters;

namespace PlayerComponent
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private InputWeapon _weaponInput;

        [SerializeField] private Character _caharcer;
        [SerializeField] private Projectile _bulletPrfeb;
        [SerializeField] private float _speedBullet;
        [SerializeField] private float _countBuleltInOneSecond;


        private FireRate _fireRate;

        private Coroutine _shootinCorutine;

        private void Awake()
        {
            Weapon weapon = new(_caharcer.ShootPoint, _bulletPrfeb, _speedBullet);
            _fireRate = new FireRate(weapon, _countBuleltInOneSecond);
        }

        private void OnEnable()
        {
            _weaponInput.Hold += Shoot;
        }

        private void OnDisable()
        {
            _weaponInput.Begin -= Shoot;
        }

        private void Shoot() => _fireRate.TryShoot();

    }
}
