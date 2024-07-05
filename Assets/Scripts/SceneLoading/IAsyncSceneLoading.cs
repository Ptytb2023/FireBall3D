using System.Threading.Tasks;
using UnityEngine;

namespace SceneLoading
{
    public interface IAsyncSceneLoading
    {
        public Task<AsyncOperation> LoadAsync(Scene scene);
        public Task<AsyncOperation> UnLoadAsync(Scene scene);
    }
}
