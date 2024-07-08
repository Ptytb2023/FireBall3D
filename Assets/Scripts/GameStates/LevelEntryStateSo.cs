using GameStates.Base;
using SceneLoading;
using UnityEngine;

using UnityObject = UnityEngine.Object;
using Scene = SceneLoading.Scene;
using Tools;
using Levels;

namespace GameStates
{
    [CreateAssetMenu(fileName = nameof(LevelEntryStateSo),
        menuName = nameof(ScriptableObject) + "/" + nameof(GameStates) + "/" + nameof(LevelEntryStateSo),
        order = 51)]
    public class LevelEntryStateSo : BaseGameStateSo
    {
        [SerializeField] private Scene _playerGeneratedPathScene;
        [SerializeField] private UnityObject _levelProvider;

        private readonly IAsyncSceneLoading _asyncSceneLoading = new AddressablesSceneLoading();
        private ILevelProvider LevelProvider => (ILevelProvider)_levelProvider;

        private void OnValidate()
        {
            Inspector.ValidateOn<ILevelProvider>(ref _levelProvider);
        }

        public override void Enter()
        {
            _asyncSceneLoading.LoadAsync(LevelProvider.Current.LocationScene);
            _asyncSceneLoading.LoadAsync(_playerGeneratedPathScene);
        }

        public override void Exit()
        {
            _asyncSceneLoading.UnLoadAsync(LevelProvider.Current.LocationScene);
            _asyncSceneLoading.UnLoadAsync(_playerGeneratedPathScene);
        }
    }
}
