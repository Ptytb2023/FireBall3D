using System.Collections;
using UnityEngine;

namespace Shooting
{
    [RequireComponent(typeof(Rigidbody))]
    public class Projectile : MonoBehaviour
    {
        private Rigidbody _rigidbody;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        public void Shoot(Vector3 postion, Vector3 direction, float speed) =>
            StartCoroutine(MoveAlong(postion, direction, speed));

        private IEnumerator MoveAlong(Vector3 postion, Vector3 direction, float speed)
        {
            _rigidbody.position = postion;
            while (enabled)
            {
                Vector3 newPostion = _rigidbody.position + direction * (speed * Time.deltaTime);
                _rigidbody.MovePosition(newPostion);

                yield return null;
            }
        }
    }
}
