using Obstacel;
using UnityEngine;

namespace Obstaicel
{
    public class RotationMovement : IMovement
    {
        private readonly Transform _transform;
        private readonly Vector3 _axis;

        public RotationMovement(Transform transform, Vector3 axis, float speed)
        {
            Speed = speed;

            _transform = transform;
            _axis = axis;
        }

        public float Speed { get; private set; }

        public void Move(float speed)
        {
            Speed = speed;
            _transform.Rotate(_axis, Speed * Time.deltaTime);
        }
    }
}
