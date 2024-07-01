using UnityEngine;
using Shooting.Pool;

namespace Shooting
{
    public class Weapon
    {
        private readonly Transform _shootPoint;
        private readonly float _speedBollet;

        private ProjectilePool _pool;

        public Weapon(Transform shootPoint, ProjectilePool projectilePool, float speedBollet)
        {
            _pool = projectilePool;
            _shootPoint = shootPoint;
            _speedBollet = speedBollet;
        }


        public void Shoot()
        {
            var bullet = _pool.Request();
            bullet.transform.position = _shootPoint.position;
            bullet.gameObject.SetActive(true);

            bullet.Shoot(_shootPoint.position, _shootPoint.forward, _speedBollet);
        }
    }
}
