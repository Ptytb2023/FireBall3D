using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.ResourceProviders;
using UnityEngine.SceneManagement;

namespace SceneLoading
{
    public class AddressablesSceneLoading : IAsyncSceneLoading
    {
        private Dictionary<string, SceneInstance> _downloadedScenes = new();


        public async Task LoadAsync(Scene scene)
        {
            if (scene.LoadMode == LoadSceneMode.Single)
                _downloadedScenes.Clear();

            SceneInstance sceneInstance = await Addressables.LoadSceneAsync(scene.Name, scene.LoadMode).Task;
            _downloadedScenes.Add(scene.Name, sceneInstance);
        }

        public async Task UnLoadAsync(Scene scene)
        {
            SceneInstance sceneToUnload = _downloadedScenes[scene.Name];
            await Addressables.UnloadSceneAsync(sceneToUnload).Task;
        }
    }
}
