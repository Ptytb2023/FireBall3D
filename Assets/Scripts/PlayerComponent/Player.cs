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
        [SerializeField] private ShootingPreferenceSo _hootingPreferenceSo;


        private FireRate _fireRate;
        private Weapon _weapon;

        private void Awake()
        {
            _weapon = _hootingPreferenceSo.GetWeapon(_caharcer.ShootPoint);
            _fireRate = _hootingPreferenceSo.GetFireRate();
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

    }
}
