using Inputs;
using Obstacles.Disappearing;
using Paths;
using Paths.Completion;
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
        private readonly IPathCompletion _pathComlition;
        private PathFolowing pathFolowing;
        private Path path;
        private PlayerInputHandler playerInputHandler;

        public PlayerPathFollowing(PathFolowing pathFolowing, Path path,
            PlayerInputHandler playerInputHandler, IPathCompletion pathComlition)
        {
            _pathComlition = pathComlition;
            _pathFolowing = pathFolowing;
            _path = path;
            _playerInputHandler = playerInputHandler;
        }

        public async void StartMovingAsync(CancellationToken cancellationToken)
        {
            IReadOnlyList<PathSegment> segments = _path.Segments;

            foreach (PathSegment pathSegment in segments)
            {
                _playerInputHandler.Disable();

                await _pathFolowing.MoveToNextAsync();

                (TowerDisassembling towerDisassembling, ObstaclesDisappearing obstacleDisappering)
                      = await pathSegment.PlatformBuilder.BuildAsync();

                if (cancellationToken.IsCancellationRequested)
                    return;

                _playerInputHandler.Enable();

                await towerDisassembling;
                await obstacleDisappering.ApllyAsync();
            }
            _pathComlition.Complete();
        }
    }
}
