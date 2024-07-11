using Levels;
using Levels.Generation;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Instalers
{
    public class PathContanierInstaler : MonoInstaller
    {
        [SerializeField] private CurrentLevelSo _currentLevelSo;

        public override void InstallBindings()
        {
            PathStructureSo pathStructure = _currentLevelSo.Current.PathStructure;
            if (pathStructure is null)
                Debug.Log("CHEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEE ZSASASASASASASASA HYITA");

            PathStructureContainer pathStructureContainer = new PathStructureContainer(pathStructure);

            Container.BindInterfacesAndSelfTo<PathStructureContainer>().FromInstance(pathStructureContainer).AsSingle().NonLazy();
        }
    }
}
