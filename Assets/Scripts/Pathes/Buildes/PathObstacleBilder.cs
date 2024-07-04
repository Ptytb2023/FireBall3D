using Obstacles;
using Obstacles.Disappearing;
using System.Collections.Generic;
using Tweening;
using UnityEngine;

namespace Assets.Scripts.Pathes.Buildes
{
    public class PathObstacleBilder : MonoBehaviour
    {
        [SerializeField] private Obstacle[] _obstaclePrefabs;
        [SerializeField] private LocalMoveTween _moveTween;


        public ObstacleDisappering Build(ObstacleCollisionFeedback collisionFeedback)
        {
            var root = transform;

            ObstacleGeneration generator = new ObstacleGeneration(_obstaclePrefabs, collisionFeedback);
            IEnumerable<Obstacle> obstacles = generator.Creat(root);

            return new ObstacleDisappering(root, obstacles, _moveTween);
        }
    }
}
