using Obstacles;
using Pathes;
using Players;
using UnityEngine;
using Random = UnityEngine.Random;
using System.ComponentModel.Composition;
using System.Threading;

namespace Levels.Generation
{
    public class LevelBuilder : MonoBehaviour
    {
        [Header("Path")]
        [SerializeField] private Transform _pathRoot;
        [SerializeField] private PathStructuresSo[] _structures;


        [Header("Player")]
        [SerializeField] private PlayerMovement _playerMovemet;
        [SerializeField] private ObstacleCollisionFeedback _obstacleCollisionFeedback;

        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();

        private void Start() => 
            Build();

        private void OnDisable() => 
            _cancellationTokenSource.Cancel();

        public void Build()
        {
            var structures = GetRandomStructuresSo();

            Path path = structures.CreatPath(_pathRoot, _obstacleCollisionFeedback, _cancellationTokenSource);

            Vector3 initialPostion = path.Segments[0].Waypoints[0].position;

            _playerMovemet.StartMovingOn(path, initialPostion, _cancellationTokenSource);
        }

        private PathStructuresSo GetRandomStructuresSo()
        {
            int index = Random.Range(0, _structures.Length);
            return _structures[index];

        }
    }
}
