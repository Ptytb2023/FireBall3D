using System.Threading.Tasks;
using DataPersistence.Files;
using DataPersistence.Saves;
using Levels;
using UnityEngine;
using Zenject;

namespace DataPersistence.Initialization
{
    public class LevelInitialization : AsyncInitialization
    {
        [SerializeField] private FilePathSo _filePath;

        private IAsyncFileService _fileService;
        private LevelNumberSo _levelNumberSo;

        [Inject]
        public void Construct(IAsyncFileService fileService, LevelNumberSo levelNumberSo)
        {
            _levelNumberSo = levelNumberSo;
            _fileService = fileService;
        }

        public override async Task InitializeAsync()
        {
            LevelNumberSo levelNumber = await _fileService.LoadAsync<LevelNumberSo>(_filePath.Value);

            if (levelNumber is null)
                return;

            _levelNumberSo.Value = levelNumber.Value;
        }
  
    }
}