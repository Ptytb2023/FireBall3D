using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tools;
using UnityEngine;
using UnityObject = UnityEngine.Object;


namespace Levels.Generation
{
    [CreateAssetMenu(fileName = nameof(PathStructuresContanerSo),
       menuName = nameof(ScriptableObject) + "/" + nameof(Levels) + "/" + nameof(PathStructuresContanerSo),
       order = 51)]
    public class PathStructuresContanerSo : ScriptableObject, IPathStructuresContaner
    {
        [SerializeField] private UnityObject _levelProvider;

        private ILevelProvider LevelProvider => (ILevelProvider)_levelProvider;

        public PathStructuresSo Value => LevelProvider.Current.PathStructuresSo;

        private void OnValidate()
        {
            Inspector.ValidateOn<ILevelProvider>(ref _levelProvider);
        }


    }
}
