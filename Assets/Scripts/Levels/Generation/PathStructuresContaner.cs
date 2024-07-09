using UnityEngine;


namespace Levels.Generation
{
    [CreateAssetMenu(fileName = nameof(PathStructuresContaner),
menuName = nameof(ScriptableObject) + "/" + nameof(Levels) + "/" + nameof(PathStructuresContaner),
order = 51)]
    public class PathStructuresContaner : ScriptableObject, IPathStructuresContaner
    {
       [SerializeField] private CurrentLevelSo _currentLevelSo;

        public PathStructuresSo Value => _currentLevelSo.Current.PathStructuresSo;
    }
}
