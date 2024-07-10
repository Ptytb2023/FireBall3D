using System.Collections.Generic;
using System.Threading.Tasks;
using Audio;
using DataPersistence.Files;
using DataPersistence.Saves;
using IoC;
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


        [Inject]
        private void Construct(IAsyncFileService fileService)
        {
            _fileService = fileService;
        }

        public override async Task InitializeAsync()
        {
            Debug.Log(_filePath.Value);
            Debug.Log(_filePath.Value);
            Debug.Log(_filePath.Value);
            Debug.Log(_filePath.Value);
            Debug.Log(_filePath.Value);
            Debug.Log(_filePath.Value);
            Debug.Log(_filePath.Value);
            await  _filePath.LoadAsync();

            var preferences = await _fileService.LoadAsync<IEnumerable<AudioPreferences>>(_filePath.Value)
                ?? EnsureCreated();

            AudioMixer mixer = await Addressables.LoadAssetAsync<AudioMixer>("AudioMixer").Task;

            GameAudio gameAudio = new GameAudio(mixer, preferences);
            gameAudio.Initialize();
            Container.Register(gameAudio);
            Container.Register<IAudioOperations>(gameAudio);
            Container.Register<IAudioPreferencesProvider>(gameAudio);
            Container.Register<IAudioStatusProvider>(gameAudio);
        }

        private IEnumerable<AudioPreferences> EnsureCreated() => new[]
            {
                new AudioPreferences(AudioGroup.BackgroundMusic, 0.0f),
                new AudioPreferences(AudioGroup.Sfx, 0.0f)
            };
    }
}