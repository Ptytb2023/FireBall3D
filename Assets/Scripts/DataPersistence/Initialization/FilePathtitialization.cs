using DataPersistence.Saves;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;

namespace DataPersistence.Initialization
{
    public class FilePathtItialization : AsyncInitialization
    {
        [SerializeField] private FilePathSo[] _filepaths;

        public async override Task InitializeAsync()
        {
            IEnumerable<Task> initializations = _filepaths.Select(x => x.LoadAsync());

            await Task.WhenAll(initializations);
        }
    }
}
