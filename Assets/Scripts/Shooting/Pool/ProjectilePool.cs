using Factores;
using Pool;
using UnityEngine;

namespace Shooting.Pool
{
    public class ProjectilePool : MonoBehaviorPool<Projectile>
    {
        [SerializeField] private int _capacity;
        [SerializeField] private ShootingPreferenceSo _shootingPreferenceSo;


        private void Awake()
        {
            IFactory<Projectile> factory = new FactoryComponent<Projectile>(_shootingPreferenceSo.Projectile);
            Initialize(factory, _capacity);
        }

    }
}
