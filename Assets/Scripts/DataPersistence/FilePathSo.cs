using System.IO;
using System.Threading.Tasks;
using UnityEngine;

namespace DataPersistence.Saves
{
    [CreateAssetMenu(fileName = "FilePath", menuName = "ScriptableObjects/Data/FilePath", order = 51)]
    public class FilePathSo : ScriptableObject
    {
        [SerializeField] private string _fileName;


        public string Value => Path.Combine(DirectoryPath, "/" + _fileName);


        private string DirectoryPath => Application.isEditor
            ? Application.streamingAssetsPath
            : Application.persistentDataPath;


        public async Task LoadAsync()
        {
            if (File.Exists(Value) == false)
            {
                await using FileStream fileStream = File.Create(Value);
            }
        }

        public void Load()
        {
            if (File.Exists(Value) == false)
            {
                using FileStream fileStream = File.Create(Value);
            }
        }
    }
}