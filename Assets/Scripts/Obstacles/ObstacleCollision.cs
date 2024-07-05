using System;
using UnityEngine;

using Inputs;
using Physics;
using Coroutines;
using Shooting;
using Shooting.Pool;


namespace Obstacles
{
    public class ObstacleCollision : MonoBehaviour
    {
        [SerializeField] private DirectionBouncedPreferenceSo _bouncedPreference;

        private ObstacleCollisionFeedback _feedback;
        private bool _hasAllradyCollider;

        public void Initialize(ObstacleCollisionFeedback feedback) =>
            _feedback = feedback;

        private void OnCollisionEnter(Collision other)
        {
            if (!other.gameObject.TryGetComponent(out Projectile projectile))
                return;

            if (_hasAllradyCollider)
                return;

            ProjectilePool pool = _feedback.PlayerProjectilePool;
            PlayerInputHandler playInput = _feedback.PlayerInput;

            _hasAllradyCollider = true;

            pool.Return(projectile);
            playInput.enabled = false;

            Vector3 hitPoint = other.contacts[0].point;

            Projectile pojetile = pool.Request();

            projectile.transform.position = hitPoint;
            projectile.gameObject.SetActive(true);

            BouncedToPlayer(projectile, hitPoint);

        }

        private void BouncedToPlayer(Projectile projectile, Vector3 hitPoint)
        {
            Vector3 position = _feedback.Player.position;
            var directionlBouncedPreferences = _bouncedPreference.DirectionlBouncedPreferences;


            var executor = new CoroutinesExecutor(projectile);
            var bounced = new DirectionalBouced(projectile.transform, executor, directionlBouncedPreferences);
            bounced.BouncedTo(position, hitPoint);
        }
    }

    [Serializable]
    public struct ObstacleCollisionFeedback
    {
        [field: SerializeField] public Transform Player { get; private set; }
        [field: SerializeField] public PlayerInputHandler PlayerInput { get; private set; }
        [field: SerializeField] public ProjectilePool PlayerProjectilePool { get; private set; }
    }
}