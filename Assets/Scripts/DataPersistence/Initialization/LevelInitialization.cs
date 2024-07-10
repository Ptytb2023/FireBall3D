using System.Threading.Tasks;
using DataPersistence.Files;
using DataPersistence.Saves;
using Levels;
using UnityEngine;
using Zenject;
using IoC;
using Levels.Generation;

namespace DataPersistence.Initialization
{
    public class LevelInitialization : AsyncInitialization
    {
        [SerializeField] private CurrentLevelSo currentLevelSo;
        [SerializeField] private FilePathSo _filePath;

        private IAsyncFileService _fileService;



        [Inject]
        public void Construct(IAsyncFileService fileService)
        {
            _fileService = fileService;
        }

        public override async Task InitializeAsync()
        {

            LevelNumber levelNumber = await _fileService.LoadAsync<LevelNumber>(_filePath.Value) ??
                new LevelNumber();
            Container.Register<ILevelNumber>(levelNumber);

            PathStructuresContaner pathStructures = new PathStructuresContaner();
            Container.Register(pathStructures);

            Container.Register<IPathStructuresContaner>(pathStructures);
            currentLevelSo.Init();

        }


    }
}