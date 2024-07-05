using GameStates.Base;
using SceneLoading;
using UnityEngine;

using Scene = SceneLoading.Scene;

namespace GameStates
{
    [CreateAssetMenu(fileName = nameof(LevelEntryStateSo),
        menuName = nameof(ScriptableObject) + "/" + nameof(GameStates) + "/" + nameof(LevelEntryStateSo),
        order = 51)]
    public class LevelEntryStateSo : BaseGameStateSo
    {
        [SerializeField] private Scene _scene;

        private readonly IAsyncSceneLoading _asyncSceneLoading = new UnitySceneLoading();


        public override void Enter() =>
            _asyncSceneLoading.LoadAsync(_scene);

        public override void Exit() =>
            _asyncSceneLoading.UnLoadAsync(_scene);
    }
}
