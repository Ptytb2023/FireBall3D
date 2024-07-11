using DataPersistence.Files;
using GameStates.States;
using Levels;
using UnityEngine;
using Zenject;

namespace Instalers
{
    public class LevelsInstaler : MonoInstaller
    {
    

        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<JsonNetFileService>().AsSingle().NonLazy();
        }
    }
}
