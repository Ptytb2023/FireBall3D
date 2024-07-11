using GameStates.Base;
using SceneLoading;
using UnityEngine;

using UnityObject = UnityEngine.Object;
using Scene = SceneLoading.Scene;
using Tools;
using Levels;
using Levels.Interfaces;
using Levels.Generation;
using IoC;

namespace GameStates.States
{
    [CreateAssetMenu(fileName = nameof(LevelEntryStateSo),
        menuName = nameof(ScriptableObject) + "/" + nameof(GameStates) + "/" + nameof(LevelEntryStateSo),
        order = 51)]
    public class LevelEntryStateSo : BaseGameStateSo
    {
        [SerializeField] private Scene _playerGeneratedPathScene;
        [SerializeField] private UnityObject _levelProvider;

        private readonly IAsyncSceneLoading _sceneLoading = new AddressablesSceneLoading();

        private ILevelProvider LevelProvider => (ILevelProvider)_levelProvider;

        private Level Level => LevelProvider.Current;

        private void OnValidate()
        {
            Inspector.ValidateOn<ILevelProvider>(ref _levelProvider);
        }

        public override void Exit()
        {
        }

        public override async void Enter()
        {

            await _sceneLoading.LoadAsync(Level.LocationScene);
            await _sceneLoading.LoadAsync(_playerGeneratedPathScene);
        }
    }
}
