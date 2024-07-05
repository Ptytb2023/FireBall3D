using UnityEngine;

namespace Obstacles
{
    public class Obstacle : MonoBehaviour
    {
        [SerializeField]  private ObstacleCollision _obstacleCollision;


        public void Initialize(ObstacleCollisionFeedback feedback) => 
            _obstacleCollision.Initialize(feedback);
    }
}
