using System.Threading.Tasks;
using UnityEngine.SceneManagement;
using Extension;
using UnityEngine;

namespace SceneLoading
{
    public class UnitySceneLoading : IAsyncSceneLoading
    {
        public async Task<AsyncOperation> LoadAsync(Scene scene) =>
            await SceneManager.LoadSceneAsync(scene.Name, scene.LoadMode);

        public async Task<AsyncOperation> UnLoadAsync(Scene scene) =>
            await SceneManager.UnloadSceneAsync(scene.Name, scene.UnloadMode);
    }
}
