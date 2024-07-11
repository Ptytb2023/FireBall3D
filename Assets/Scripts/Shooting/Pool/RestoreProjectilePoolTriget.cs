using System;
using UnityEngine;

namespace Shooting.Pool
{
    [RequireComponent(typeof(Collider))]
    public class RestoreProjectilePoolTriget : MonoBehaviour
    {
        [SerializeField] private ProjectilePool _pool;

        public event Action ProjectileReturned;


        public void Initialize(ProjectilePool pool) =>
            _pool = pool;

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out Projectile projectile))
            {
                _pool.Return(projectile);
                ProjectileReturned?.Invoke();
            }
        }

        private void OnValidate() =>
            GetComponent<Collider>().isTrigger = true;
    }
}
