using DataPersistence.Files;
using Levels;
using UnityEngine;
using Zenject;

namespace DataPersistence.Saves.Saves
{
    public class LevelSave : MonoBehaviour
    {
        [SerializeField] private FilePathSo _filePath;

        private IAsyncFileService _fileService;

        
        private LevelNumberSo _levelNumberSo;

        [Inject]
        public void Construct(IAsyncFileService asyncFileService, LevelNumberSo levelNumberSo)
        {
            _levelNumberSo = levelNumberSo;
            _fileService = asyncFileService;
        }

        private void OnApplicationQuit()
        {
            _fileService.SaveAsync(_levelNumberSo, _filePath.Value);
        }
    }
}