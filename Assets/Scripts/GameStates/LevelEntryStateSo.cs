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
        [SerializeField] private Scene _locationScene;
        [SerializeField] private Scene _playerGeneratedPathScene;

        private readonly IAsyncSceneLoading _asyncSceneLoading = new AddressablesSceneLoading();


        public override void Enter()
        {
            _asyncSceneLoading.LoadAsync(_locationScene);
            _asyncSceneLoading.LoadAsync(_playerGeneratedPathScene);
        }

        public override void Exit()
        {
            _asyncSceneLoading.UnLoadAsync(_locationScene);
            _asyncSceneLoading.UnLoadAsync(_playerGeneratedPathScene);
        }
    }
}
