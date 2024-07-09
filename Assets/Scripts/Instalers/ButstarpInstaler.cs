using System;
using Zenject;
using DataPersistence.Files;
using UnityEngine;
using Levels;
using Audio;
using System.Collections.Generic;
using UnityEngine.AddressableAssets;
using UnityEngine.Audio;
using DataPersistence.Saves;

namespace Instalers
{
    public class ButstarpInstaler : MonoInstaller
    {
        [SerializeField] private LevelNumberSo _levelNumberSo;
        [SerializeField] private FilePathSo _pathToAudio;
        [SerializeField] private AudioMixer _mixer;

        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<JsonNetFileService>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<LevelNumberSo>().FromInstance(_levelNumberSo).AsSingle().NonLazy();
            Test();
        }

        private void Test()
        {
            _pathToAudio.Load();


            var filleSetvie = Container.Resolve<JsonNetFileService>();

            IEnumerable<AudioPreferences> preferences =
                filleSetvie.Load<IEnumerable<AudioPreferences>>(_pathToAudio.Value);

            if (preferences is null)
                preferences = EnsureCreated();


            GameAudio gameAudio = new GameAudio(_mixer, preferences);
            gameAudio.Initialize();

            Container.BindInterfacesAndSelfTo<GameAudio>().FromInstance(gameAudio);
        }

        private IEnumerable<AudioPreferences> EnsureCreated() => new[]
          {
                new AudioPreferences(AudioGroup.BackgroundMusic, 0.0f),
                new AudioPreferences(AudioGroup.Sfx, 0.0f)
            };
    }
}
