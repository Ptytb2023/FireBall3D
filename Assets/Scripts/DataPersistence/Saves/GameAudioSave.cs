using System.Collections.Generic;
using Audio;
using DataPersistence.Files;
using IoC;
using UnityEngine;
using Zenject;

namespace DataPersistence.Saves.Saves
{
    public class GameAudioSave : MonoBehaviour
    {
        [SerializeField] private FilePathSo _filePath;

        private IAsyncFileService _fileService;


        [Inject]
        public void Construct(IAsyncFileService fileService)
        {
            _fileService = fileService;
        }


        private void OnApplicationQuit()
        {
            var audioPreferences = Container.InstanceOf<IAudioPreferencesProvider>().Preferences;
            _fileService.SaveAsync(audioPreferences, _filePath.Value);
        }
    }
}