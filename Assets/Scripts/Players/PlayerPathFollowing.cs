using Inputs;
using Obstacles.Disappearing;
using Pathes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Towers.Disassembling;

namespace Players
{
    public class PlayerPathFollowing
    {
        private readonly PathFolowing _pathFolowing;
        private readonly Path _path;
        private readonly PlayerInputHandler _playerInputHandler;

        public PlayerPathFollowing(PathFolowing pathFolowing, Path path, PlayerInputHandler playerInputHandler)
        {

            _pathFolowing = pathFolowing;
            _path = path;
            _playerInputHandler = playerInputHandler;
        }

        public async void StartMovingAsync(CancellationToken cancellationToken)
        {
            IReadOnlyList<SegmentPath> segments = _path.Segments;

            foreach (SegmentPath pathSegment in segments)
            {
                _playerInputHandler.Disable();

                await _pathFolowing.MoveToNextAsync();

                (TowerDisassembling towerDisassembling, ObstacleDisappering obstacleDisappering)
                      = await pathSegment.PathPlatformBuilder.BuildAsync();

                if (cancellationToken.IsCancellationRequested)
                    return;

                _playerInputHandler.Enable();

                await towerDisassembling;
                await obstacleDisappering.ApllyAsync();
            }
        }
    }
}
