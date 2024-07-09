using System.Collections.Generic;
using Audio;
using DataPersistence.Files;
using UnityEngine;
using Zenject;

namespace DataPersistence.Saves.Saves
{
    public class GameAudioSave : MonoBehaviour
    {
        [SerializeField] private FilePathSo _filePath;

        private IAsyncFileService _fileService;

        private GameAudio _audio;

        [Inject]
        public void Construct(IAsyncFileService fileService)
        {
            _fileService = fileService;
        }

        public void Initioalize(GameAudio gameAudio)
        {
            _audio = gameAudio;
        }

        private void OnApplicationQuit()
        {
            IEnumerable<AudioPreferences> audioPreferences = _audio.Preferences;
            _fileService.SaveAsync(audioPreferences, _filePath.Value);
        }
    }
}