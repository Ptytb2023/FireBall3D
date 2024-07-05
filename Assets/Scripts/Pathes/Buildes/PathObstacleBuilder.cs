using Obstacles;
using Obstacles.Disappearing;
using System.Collections.Generic;
using Tweening;
using UnityEngine;

namespace Pathes.Buildes
{
    public class PathObstacleBuilder : MonoBehaviour
    {
        [SerializeField] private Transform _root;
        [SerializeField] private LocalMoveTweenSo _moveTween;

        private IReadOnlyList<Obstacle> _obstaclePrefabs;


        public void Initialize(IReadOnlyList<Obstacle> obstacles)
        {
            _obstaclePrefabs = obstacles;
        }

        public ObstacleDisappering Build(ObstacleCollisionFeedback collisionFeedback)
        {
            var root = transform;

            ObstacleGeneration generator = new ObstacleGeneration(_obstaclePrefabs, collisionFeedback);
            IEnumerable<Obstacle> obstacles = generator.Creat(root);

            return new ObstacleDisappering(root, obstacles, _moveTween);
        }
    }
}
