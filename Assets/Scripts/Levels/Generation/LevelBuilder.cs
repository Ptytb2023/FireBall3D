using Obstacles;
using Pathes;
using Players;
using UnityEngine;
using System.Threading;
using Zenject;
using IoC;

namespace Levels.Generation
{
    public class LevelBuilder : MonoBehaviour
    {
        [Header("Path")]
        [SerializeField] private Transform _pathRoot;


        [Header("Player")]
        [SerializeField] private PlayerMovement _playerMovemet;
        [SerializeField] private ObstacleCollisionFeedback _obstacleCollisionFeedback;

        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();


        private IPathStructuresContaner _pathStructuresContaner =>
            Container.InstanceOf<IPathStructuresContaner>();



        private void Start() =>
            Build();

        private void OnDisable() =>
            _cancellationTokenSource.Cancel();

        public void Build()
        {
            var structures = _pathStructuresContaner.Value;

            Path path = structures.CreatPath(_pathRoot, _obstacleCollisionFeedback, _cancellationTokenSource);

            Vector3 initialPostion = path.Segments[0].Waypoints[0].position;

            _playerMovemet.StartMovingOn(path, initialPostion, _cancellationTokenSource);
        }


    }
}
