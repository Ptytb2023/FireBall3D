using Obstacles;
using Pathes;
using Players;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Levels.Generation
{
    public class LevelBuilder : MonoBehaviour 
    {
        [Header("Path")]
        [SerializeField] private Transform _pathRoot;
        [SerializeField] private LevelesStructuresSo _structures;


        [Header("Player")]
        [SerializeField] private PlayerMovement _playerMovemet;
        [SerializeField] private ObstacleCollisionFeedback _obstacleCollisionFeedback;

        private void Start()
        {
            Build();
        }

        public void Build()
        {
            Path path = _structures.CreatPath(_pathRoot, _obstacleCollisionFeedback);

            Vector3 initialPostion = path.Segments[0].Waypoints[0].position;

            _playerMovemet.StartMovingOn(path, initialPostion);
        }
    }
}
