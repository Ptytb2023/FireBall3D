using UnityEngine;

namespace Shooting
{
    public class FireRate
    {
        private readonly float _countShootInOneSecond;

        private float _lastShootTime;

        public FireRate(float countShootInOneSecond) => 
            _countShootInOneSecond = countShootInOneSecond;

        private bool IsCanShoot => Time.time >= _lastShootTime + 1 / _countShootInOneSecond;

        public void TryShoot(Weapon weapon)
        {
            if (IsCanShoot == false)
                return;

            weapon.Shoot();
            _lastShootTime = Time.time;
        }
    }
}