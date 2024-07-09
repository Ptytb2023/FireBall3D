using Obstacles;
using Obstacles.Disappearing;
using System.Threading;
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
        private CancellationTokenSource _cancellationTokenSource;

        public void Intialize(PathPlatfromStructure pathPaltform,
            ObstacleCollisionFeedback obstacleCollisionFeedback, CancellationTokenSource cancellationTokenSource)
        {
            _cancellationTokenSource = cancellationTokenSource;
            _toweBuilder.Initialize(pathPaltform.TowerStructures, cancellationTokenSource);
            _obstacleBilder.Initialize(pathPaltform.ObstaclesPrefab);

            _obstacleFeedback = obstacleCollisionFeedback;
        }

        public async Task<(TowerDisassembling, ObstacleDisappering)> BuildAsync()
        {
            TowerDisassembling disassembling = await _toweBuilder.BuildAsync(_obstacleFeedback.PlayerProjectilePool);
            if (_cancellationTokenSource.IsCancellationRequested)
                return (disassembling, null);

            ObstacleDisappering disappering = _obstacleBilder.Build(_obstacleFeedback);

            return (disassembling, disappering);
        }
    }
}
