using System.Threading.Tasks;
using UnityEngine.SceneManagement;
using Extension;

namespace SceneLoading
{
    public class UnitySceneLoading : IAsyncSceneLoading
    {
        public async Task LoadAsync(Scene scene) =>
            await SceneManager.LoadSceneAsync(scene.Name, scene.LoadMode);

        public async Task UnLoadAsync(Scene scene) =>
            await SceneManager.UnloadSceneAsync(scene.Name, scene.UnloadMode);
    }
}
