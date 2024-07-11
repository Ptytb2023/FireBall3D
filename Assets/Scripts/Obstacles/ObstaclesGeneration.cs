using System;
using System.Collections.Generic;
using UnityEngine;

using UnityObject = UnityEngine.Object;
using Random = UnityEngine.Random;


namespace Obstacles
{
    public class ObstaclesGeneration
    {
        private readonly IReadOnlyList<Obstacle> _obstaclesPrefabs;
        private readonly ObstacleCollisionFeedback _collisionFeedback;

        public ObstaclesGeneration(IReadOnlyList<Obstacle> obstaclesPrefabs,
            ObstacleCollisionFeedback collisionFeedback)
        {
            _obstaclesPrefabs = obstaclesPrefabs ?? throw new ArgumentNullException(nameof(obstaclesPrefabs));
            _collisionFeedback = collisionFeedback; 
        }

        public IEnumerable<Obstacle> Creat(Transform root)
        {
            int count = _obstaclesPrefabs.Count;
            var createdObtacles = new Obstacle[count];

            for (int i = 0; i < count; i++)
            {
                Obstacle newObstacle = UnityObject.Instantiate(_obstaclesPrefabs[i], root);
                newObstacle.Initialize(_collisionFeedback);
                newObstacle.transform.eulerAngles = RandomVector3Y();

                createdObtacles[i] = newObstacle;
            }

            return createdObtacles;
        }

        private Vector3 RandomVector3Y()
        {
            return Vector3.up * Random.Range(0, 360);
        }
    }
}
