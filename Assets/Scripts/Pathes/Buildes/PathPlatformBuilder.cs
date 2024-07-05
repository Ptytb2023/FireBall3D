using Obstacles;
using Obstacles.Disappearing;
using System.Threading.Tasks;
using Towers.Disassembling;
using UnityEngine;

namespace Pathes.Buildes
{
    public class PathPlatformBuilder : MonoBehaviour
    {
        [SerializeField] private PathObstacleBuilder _obstacleBilder;
        [SerializeField] private PathTowerBuilder _toweBuilder;

        private ObstacleCollisionFeedback _obstacleFeedback;
        public void Intialize(PathPaltform pathPaltform, ObstacleCollisionFeedback obstacleCollisionFeedback)
        {
            _toweBuilder.Initialize(pathPaltform.TowerStructures);
            _obstacleBilder.Initialize(pathPaltform.ObstaclesPrefab);

            _obstacleFeedback = obstacleCollisionFeedback;
        }

        public async Task<(TowerDisassembling, ObstacleDisappering)> BuildAsync()
        {
            TowerDisassembling disassembling = await _toweBuilder.BuildAsync(_obstacleFeedback.PlayerProjectilePool);
            ObstacleDisappering disappering = _obstacleBilder.Build(_obstacleFeedback);

            return (disassembling, disappering);
        }
    }
}
