using Inputs;
using Obstacles.Disappearing;
using Pathes;
using Pathes.Complition;
using System.Collections.Generic;
using System.Threading;
using Towers.Disassembling;

namespace Players
{
    public class PlayerPathFollowing
    {
        private readonly PathFolowing _pathFolowing;
        private readonly Path _path;
        private readonly PlayerInputHandler _playerInputHandler;
        private readonly IPathComlition _pathComlition;
        private PathFolowing pathFolowing;
        private Path path;
        private PlayerInputHandler playerInputHandler;

        public PlayerPathFollowing(PathFolowing pathFolowing, Path path,
            PlayerInputHandler playerInputHandler, IPathComlition pathComlition)
        {
            _pathComlition = pathComlition;
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
            _pathComlition.Complited();
        }
    }
}
