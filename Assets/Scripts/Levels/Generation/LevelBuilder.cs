using System.Threading;
using IoC;
using Obstacles;
using Paths;
using Players;
using UnityEngine;
using Zenject;

namespace Levels.Generation
{
    public class LevelBuilder : MonoBehaviour
    {
        [Header("Path")]
        [SerializeField] private Transform _pathRoot;

        [Header("Player")]
        [SerializeField] private PlayerMovement _playerMovement;
        [SerializeField] private ObstacleCollisionFeedback _obstacleCollisionFeedback;

        [SerializeField] private CurrentLevelSo _currentLevelSo;

        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();

        private void Start() =>
            Build();

        private void OnDisable() =>
            _cancellationTokenSource.Cancel();

        private void Build()
        {
            Path path = _currentLevelSo.Current.PathStructure
                .CreatePath(_pathRoot, _obstacleCollisionFeedback, _cancellationTokenSource);

            Vector3 initialPosition = path.Segments[0].Waypoints[0].position;

            _playerMovement.StartMovingOn(path, initialPosition, _cancellationTokenSource);
        }
    }
}