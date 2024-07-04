using UnityEngine;

namespace Obstacles
{
    public class Obstacle : MonoBehaviour
    {
        [SerializeField]  private ObstacleCollision _obstacleCollision;


        public void Initialized(ObstacleCollisionFeedback feedback) => 
            _obstacleCollision.Initialized(feedback);
    }
}
