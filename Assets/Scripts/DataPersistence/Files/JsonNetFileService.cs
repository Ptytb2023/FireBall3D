using System.IO;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace DataPersistence.Files
{
	public class JsonNetFileService : IAsyncFileService
	{
		public async Task<TModel> LoadAsync<TModel>(string filePath)
		{
			using var reader = new StreamReader(filePath);

			string json = await reader.ReadToEndAsync();

			return JsonConvert.DeserializeObject<TModel>(json);
		}

		public async Task SaveAsync<TModel>(TModel model, string filePath)
		{
			using var writer = new StreamWriter(filePath);

			string json = JsonConvert.SerializeObject(model, Formatting.Indented);

			await writer.WriteAsync(json);
		}

		public TModel Load<TModel>(string filePath)
		{
            using var reader = new StreamReader(filePath);

            string json =  reader.ReadToEnd();

            return JsonConvert.DeserializeObject<TModel>(json);
        }

    }
}