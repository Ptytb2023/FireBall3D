using System.Collections.Generic;
using System.Threading.Tasks;
using Tweening;
using UnityEngine;

using UnityObject = UnityEngine.Object;

namespace Obstacles.Disappearing
{
    public class ObstacleDisappering
    {
        private readonly Transform _root;
        private readonly IEnumerable<Obstacle> _obtacles;
        private IAwaitableTweenAnimation _animation;

        public ObstacleDisappering(Transform root,
            IEnumerable<Obstacle> obtacles,
            IAwaitableTweenAnimation animation)
        {
            _root = root;
            _obtacles = obtacles;
            _animation = animation;
        }

        public async Task ApllyAsync()
        {
            await _animation.ApplyTo(_root);

            foreach (var obstacel in _obtacles)
                UnityObject.Destroy(obstacel.gameObject);

            await Task.CompletedTask;
        }
    }
}
