using System;
using Zenject;
using DataPersistence.Files;
using UnityEngine;
using Levels;

namespace Instalers
{
    public class ButstarpInstaler : MonoInstaller
    {
        [SerializeField] private LevelNumberSo _levelNumberSo;

        public override void InstallBindings()
        {
            Container.Bind<IAsyncFileService>().To<JsonNetFileService>().AsSingle().NonLazy();
            Container.Bind<ILevelNumberSo>().FromInstance(_levelNumberSo).AsSingle().NonLazy();

        }
    }
}
