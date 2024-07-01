using Factores;
using Pool;
using Shooting;
using UnityEngine;

namespace Assets.Scripts.Pool
{
    public class ProjectilePool : MonoBehaviorPool<Projectile>
    {
        [SerializeField] private int _capacity;
        [SerializeField] private ShootingPreferenceSo _shootingPreferenceSo;


        private void Awake()
        {
            IFactory<Projectile> factory = new FactoryComponent<Projectile>(_shootingPreferenceSo.Projectile);
            Init(factory, _capacity);
        }

    }
}
