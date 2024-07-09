using GameStates.States;
using Levels;
using Levels.Generation;
using UnityEngine;
using Zenject;

namespace Instalers
{
    public class LevelsInstaler : MonoInstaller
    {
        [SerializeField] private PathStructuresContaner _pathStructuresContaner;
        [SerializeField] private CurrentLevelSo _currentLevelSo;
        [SerializeField] private LevelEntryStateSo _levelEntryStateSo;
        [SerializeField] private LevelsStoreSo _levelsStoreSo;

        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<LevelsStoreSo>().FromInstance(_levelsStoreSo).AsSingle().NonLazy();

            Container.BindInterfacesAndSelfTo<PathStructuresContaner>().
                FromInstance(_pathStructuresContaner).AsSingle().NonLazy();

            Container.Bind<LevelNumberSo>().AsSingle().NonLazy();

            Container.BindInterfacesAndSelfTo<CurrentLevelSo>().FromInstance(_currentLevelSo).AsSingle().NonLazy();

            Container.Bind<LevelEntryStateSo>().FromInstance(_levelEntryStateSo);
        }
    }
}
