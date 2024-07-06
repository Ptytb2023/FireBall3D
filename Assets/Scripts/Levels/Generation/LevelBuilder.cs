using Obstacles;
using Pathes;
using Players;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Levels.Generation
{
    public class LevelBuilder : MonoBehaviour
    {
        [Header("Path")]
        [SerializeField] private Transform _pathRoot;
        [SerializeField] private LevelesStructuresSo[] _structures;


        [Header("Player")]
        [SerializeField] private PlayerMovement _playerMovemet;
        [SerializeField] private ObstacleCollisionFeedback _obstacleCollisionFeedback;

        private void Start()
        {
            Build();
        }

        public void Build()
        {
            var structures = GetRandomStructuresSo();

            Path path = structures.CreatPath(_pathRoot, _obstacleCollisionFeedback);

            Vector3 initialPostion = path.Segments[0].Waypoints[0].position;

            _playerMovemet.StartMovingOn(path, initialPostion);
        }

        private LevelesStructuresSo GetRandomStructuresSo()
        {
            int index = Random.Range(0, _structures.Length);
            return _structures[index];

        }
    }
}
