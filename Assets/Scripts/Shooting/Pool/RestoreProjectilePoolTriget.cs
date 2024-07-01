using UnityEngine;

namespace Shooting.Pool
{
    [RequireComponent(typeof(Collider))]
    public class RestoreProjectilePoolTriget : MonoBehaviour
    {
        [SerializeField] private ProjectilePool _pool;


        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out Projectile projectile))
                _pool.Return(projectile);
        }
        private void OnValidate() =>
            GetComponent<Collider>().isTrigger = true;
    }
}
