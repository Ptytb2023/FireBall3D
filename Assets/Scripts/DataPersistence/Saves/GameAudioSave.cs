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

        private readonly IAsyncFileService _fileService = new JsonNetFileService();

        [Inject]
        private GameAudio _audio;

        private void OnApplicationQuit()
        {
            IEnumerable<AudioPreferences> audioPreferences = _audio.Preferences;
            _fileService.SaveAsync(audioPreferences, _filePath.Value);
        }
    }
}