using UnityEngine;

namespace Assets.Scripts.Structures
{
    public class UnityTime
    {
        private float _enterTime;
        private float _duration;

        public bool IsTimeUp => Time.time <= _enterTime + _duration;
        public float ElapsedTimePresent => (Time.time - _enterTime) / _duration;

        public void Start(float duration)
        {
            _duration = duration;
            _enterTime = Time.time;
        }
    }
}
