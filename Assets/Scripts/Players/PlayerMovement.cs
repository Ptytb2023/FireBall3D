using Pathes.Complition;
using GameStates.Base;
using Inputs;
using Pathes;
using System.Threading;
using UnityEngine;

namespace Players
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private MovebelPreferenceSo _movebelPreferenceSo;
        [SerializeField] private PlayerInputHandler _playerInputHandler;
        [SerializeField] private GameStateMachineSo _gameStateMachine;

        [SerializeField] private Transform _player;


        public void StartMovingOn(Path path, Vector3 initialPosition, CancellationTokenSource cancellationTokenSource)
        {
            _player.position = initialPosition;
            IPathComlition levelPathComplition = new LevelPathComplition(_gameStateMachine);
            PathFolowing pathFolowing = new PathFolowing(path, _movebelPreferenceSo, _player);

            PlayerPathFollowing playerFollosing = new(pathFolowing, path, _playerInputHandler, levelPathComplition);
            playerFollosing.StartMovingAsync(cancellationTokenSource.Token);
        }
    }
}
