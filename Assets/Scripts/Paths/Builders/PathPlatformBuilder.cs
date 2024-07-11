using System.Threading;
using System.Threading.Tasks;
using Obstacles;
using Obstacles.Disappearing;
using Towers.Disassembling;
using UnityEngine;

namespace Paths.Builders
{
	public class PathPlatformBuilder : MonoBehaviour
	{
		[SerializeField] private PathTowerBuilder _towerBuilder;
		[SerializeField] private PathObstaclesBuilder _obstaclesBuilder;

		private ObstacleCollisionFeedback _obstacleCollisionFeedback;
		private CancellationTokenSource _cancellationTokenSource;
		
		public void Initialize(PathPlatformStructure pathPlatformStructure,
			ObstacleCollisionFeedback collisionFeedback,
			CancellationTokenSource cancellationTokenSource)
		{
			_towerBuilder.Initialize(pathPlatformStructure.TowerStructure);
			_obstaclesBuilder.Initialize(pathPlatformStructure.Obstacles);

			_obstacleCollisionFeedback = collisionFeedback;
			_cancellationTokenSource = cancellationTokenSource;
		}

		public async Task<(TowerDisassembling, ObstaclesDisappearing)> BuildAsync()
		{
			TowerDisassembling disassembling = await _towerBuilder.BuildAsync(_obstacleCollisionFeedback.PlayerProjectilePool,
				_cancellationTokenSource.Token);

			if (_cancellationTokenSource.IsCancellationRequested)
				return (disassembling, null);
			
			ObstaclesDisappearing disappearing = _obstaclesBuilder.Build(_obstacleCollisionFeedback);
			
			return (disassembling, disappearing);
		}
	}
}