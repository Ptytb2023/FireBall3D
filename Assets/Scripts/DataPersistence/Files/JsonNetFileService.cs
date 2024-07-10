using System.IO;
using System.Threading.Tasks;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.Android;

namespace DataPersistence.Files
{
    public class JsonNetFileService : IAsyncFileService
    {
        public async Task<TModel> LoadAsync<TModel>(string filePath)
        {
            PermissionReques();

            Debug.Log($"File.Exists(filePath):{File.Exists(filePath)}");
            Debug.Log($"File.Exists(filePath):{File.Exists(filePath)}");
            Debug.Log($"File.Exists(filePath):{File.Exists(filePath)}");
            Debug.Log($"File.Exists(filePath):{File.Exists(filePath)}");
            Debug.Log($"File.Exists(filePath):{File.Exists(filePath)}");
            Debug.Log($"File.Exists(filePath):{File.Exists(filePath)}");
            Debug.Log($"File.Exists(filePath):{File.Exists(filePath)}");

            if (File.Exists(filePath) == false)
            {
                await using FileStream fileStream = File.Create(filePath);
            }
            using var reader = new StreamReader(filePath);

            string json = await reader.ReadToEndAsync();

            return JsonConvert.DeserializeObject<TModel>(json);
        }

        public async Task SaveAsync<TModel>(TModel model, string filePath)
        {
            PermissionReques();

            Debug.Log($"Saave  File.Exists(filePath):{File.Exists(filePath)}");
            Debug.Log($"Saave  File.Exists(filePath):{File.Exists(filePath)}");
            Debug.Log($"Saave  File.Exists(filePath):{File.Exists(filePath)}");
            Debug.Log($"Saave  File.Exists(filePath):{File.Exists(filePath)}");
            Debug.Log($"Saave  File.Exists(filePath):{File.Exists(filePath)}");
            Debug.Log($"Saave  File.Exists(filePath):{File.Exists(filePath)}");
            Debug.Log($"Saave  File.Exists(filePath):{File.Exists(filePath)}");


            if (File.Exists(filePath) == false)
            {
                await using FileStream fileStream = File.Create(filePath);
            }

            using var writer = new StreamWriter(filePath);

            string json = JsonConvert.SerializeObject(model, Formatting.Indented);

            await writer.WriteAsync(json);
        }

        public TModel Load<TModel>(string filePath)
        {
            PermissionReques();

            if (File.Exists(filePath))
            {
                File.Create(filePath);
            }

            var reader = new StreamReader(filePath);

            string json = reader.ReadToEnd();

            return JsonConvert.DeserializeObject<TModel>(json);
        }

        private void PermissionReques()
        {
            bool isRead = Permission.HasUserAuthorizedPermission(Permission.ExternalStorageRead);
            bool isWrite = Permission.HasUserAuthorizedPermission(Permission.ExternalStorageWrite);


            UnityEngine.Debug.Log($"isWrite = {isWrite}, isRead = {isRead}");

            if (!(isRead && isWrite))
            {
                Permission.RequestUserPermission(Permission.ExternalStorageRead);
                Permission.RequestUserPermission(Permission.ExternalStorageWrite);
            }
        }

    }
}