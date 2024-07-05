using Inputs;
using Pathes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Players
{
    public class PlayerMovement
    {
        [SerializeField] private MovebelPreferenceSo _movebelPreferenceSo;
        [SerializeField] private PlayerInputHandler _playerInputHandler;

        [SerializeField] private Transform _player;

        public void StartMovingOn(Path path, Vector3 initialPosition)
        {
            _player.position = initialPosition;

            new PlayerPathFollowing(
                new PathFolowing(path, _movebelPreferenceSo, _player),
                path,
                _playerInputHandler).StartMovingAsync();
        }
    }
}
