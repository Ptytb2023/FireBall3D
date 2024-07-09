using System.Collections.Generic;
using System.Threading.Tasks;
using Audio;
using DataPersistence.Files;
using DataPersistence.Saves;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.Audio;
using Zenject;

namespace DataPersistence.Initialization
{
    public class GameAudioInitialization : AsyncInitialization
    {
        [SerializeField] private FilePathSo _filePath;

        private IAsyncFileService _fileService;

        private DiContainer _container;

        [Inject]
        private void Construct(IAsyncFileService fileService, DiContainer container)
        {
            _container = container;
            _fileService = fileService;
        }

        public override async Task InitializeAsync()
        {
            var preferences = await _fileService.LoadAsync<IEnumerable<AudioPreferences>>(_filePath.Value)
                ?? EnsureCreated();

            AudioMixer mixer = await Addressables.LoadAssetAsync<AudioMixer>("AudioMixer").Task;

            GameAudio gameAudio = new GameAudio(mixer, preferences);
            gameAudio.Initialize();

            _container.BindInterfacesAndSelfTo<GameAudio>().FromInstance(gameAudio);
        }

        private IEnumerable<AudioPreferences> EnsureCreated() => new[]
            {
                new AudioPreferences(AudioGroup.BackgroundMusic, 0.0f),
                new AudioPreferences(AudioGroup.Sfx, 0.0f)
            };
    }
}