using Obstacles;
using Pathes;
using Players;
using UnityEngine;
using Random = UnityEngine.Random;
using System.Threading;
using UnityObject = UnityEngine.Object;
using Tools;

namespace Levels.Generation
{
    public class LevelBuilder : MonoBehaviour
    {
        [Header("Path")]
        [SerializeField] private Transform _pathRoot;
        [SerializeField] private UnityObject _pathStructerContanier;


        [Header("Player")]
        [SerializeField] private PlayerMovement _playerMovemet;
        [SerializeField] private ObstacleCollisionFeedback _obstacleCollisionFeedback;

        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();

        private IPathStructuresContaner PathStructuresContaner => (IPathStructuresContaner)_pathStructerContanier;

        private void OnValidate() => 
            Inspector.ValidateOn<IPathStructuresContaner>(ref _pathStructerContanier);

        private void Start() =>
            Build();

        private void OnDisable() =>
            _cancellationTokenSource.Cancel();

        public void Build()
        {
            var structures = PathStructuresContaner.Value;

            Path path = structures.CreatPath(_pathRoot, _obstacleCollisionFeedback, _cancellationTokenSource);

            Vector3 initialPostion = path.Segments[0].Waypoints[0].position;

            _playerMovemet.StartMovingOn(path, initialPostion, _cancellationTokenSource);
        }


    }
}
