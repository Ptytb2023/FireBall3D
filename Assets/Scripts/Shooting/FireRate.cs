using UnityEngine;

namespace Shooting
{
    public class FireRate
    {
        private readonly Weapon _weapon;
        private readonly float _countShootInOneSecond;

        private float _lastShootTime;

        public FireRate(Weapon weapon, float countShootInOneSecond)
        {
            _weapon = weapon;
            _countShootInOneSecond = countShootInOneSecond;
        }

        private bool IsCanShoot => Time.time >= _lastShootTime + 1 / _countShootInOneSecond;

        public void TryShoot()
        {
            if (IsCanShoot == false)
                return;

            _weapon.Shoot();
            _lastShootTime = Time.time;
        }
    }
}