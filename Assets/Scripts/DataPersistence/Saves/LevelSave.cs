using DataPersistence.Files;
using Levels;
using UnityEngine;
using Zenject;
using IoC;

namespace DataPersistence.Saves.Saves
{
    public class LevelSave : MonoBehaviour
    {
        [SerializeField] private FilePathSo _filePath;

        private IAsyncFileService _fileService;



        [Inject]
        public void Construct(IAsyncFileService asyncFileService)
        {
            _fileService = asyncFileService;
        }

        private void OnApplicationQuit()
        {
            var levelNumber = Container.InstanceOf<ILevelNumber>();

            _fileService.SaveAsync(levelNumber, _filePath.Value);
        }
    }
}