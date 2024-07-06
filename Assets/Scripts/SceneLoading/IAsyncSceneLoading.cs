using System.Threading.Tasks;
using UnityEngine;

namespace SceneLoading
{
    public interface IAsyncSceneLoading
    {
        public Task LoadAsync(Scene scene);
        public Task UnLoadAsync(Scene scene);
    }
}
