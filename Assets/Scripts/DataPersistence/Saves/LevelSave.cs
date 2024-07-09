using DataPersistence.Files;
using Levels;
using UnityEngine;
using Zenject;

namespace DataPersistence.Saves.Saves
{
	public class LevelSave : MonoBehaviour
	{
		[SerializeField] private FilePathSo _filePath;
	
		private readonly IAsyncFileService _fileService = new JsonNetFileService();

		[Inject]
		private LevelNumberSo _levelNumberSo;

		private void OnApplicationQuit()
		{
			_fileService.SaveAsync(_levelNumberSo, _filePath.Value);
		}
	}
}