using Coroutines;
using Inputs;
using Physics;
using Shooting;
using Shooting.Pool;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


namespace Obstacle
{
    public class ObstacleCollision : MonoBehaviour
    {
        [SerializeField] private Transform _player;
        [SerializeField] private InputWeapon _playerInput;
        [SerializeField] private ProjectilePool _pool;

        [SerializeField] private DirectionBouncedPreferenceSo _bouncedPreference;

        private bool _hasAllradyCollider;

        private void OnCollisionEnter(Collision other)
        {
            if (!other.gameObject.TryGetComponent(out Projectile projectile))
                return;

            if (_hasAllradyCollider)
                return;

            _hasAllradyCollider = true;

            _pool.Return(projectile);
            _playerInput.enabled = false;

            Vector3 hitPoint = other.contacts[0].point;

            Projectile pojetile = _pool.Request();
            projectile.transform.position = hitPoint;
            projectile.gameObject.SetActive(true);

            var executor = new CoroutinesExecutor(projectile);
            var bounced = new DirectionalBouced(projectile.transform, executor, _bouncedPreference.DirectionlBouncedPreferences);
            bounced.BouncedTo(_player.position, hitPoint);

        }
    }
}