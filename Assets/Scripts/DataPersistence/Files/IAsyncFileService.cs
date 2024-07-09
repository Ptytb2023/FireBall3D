using System.Threading.Tasks;

namespace DataPersistence.Files
{
	public interface IAsyncFileService
	{
		Task<TModel> LoadAsync<TModel>(string filePath);
		Task SaveAsync<TModel>(TModel model, string filePath);
	}
}