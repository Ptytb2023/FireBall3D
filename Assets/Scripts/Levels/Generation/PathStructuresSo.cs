using Obstacles;
using Pathes;
using Pathes.Buildes;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

namespace Levels.Generation
{
    [CreateAssetMenu(fileName = nameof(PathStructuresSo),
        menuName = nameof(ScriptableObject) + "/" + nameof(Levels) + "/" + nameof(PathStructuresSo),
        order = 51)]
    public class PathStructuresSo : ScriptableObject
    {
        [SerializeField] private Path _pathPrefab;
        [SerializeField] List<PathPlatfromStructure> _plaforms = new();


        private void OnValidate()
        {
            if (_pathPrefab is null)
                return;

            for (int i = _plaforms.Count; i < _pathPrefab.Segments.Count; i++)
            {
                _plaforms.Add(default);
            }
        }

        public  Path CreatPath(Transform root, ObstacleCollisionFeedback feedback, CancellationTokenSource cancellationTokenSource)
        {
            Path path = Instantiate(_pathPrefab, root);
            path.Initialize(_plaforms, feedback, cancellationTokenSource);

            return path;
        }
    }
}
