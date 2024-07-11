﻿using GameStates.Base;
using SceneLoading;
using UnityEngine;

using UnityObject = UnityEngine.Object;
using Scene = SceneLoading.Scene;
using Tools;
using Levels;

namespace GameStates.States
{
    [CreateAssetMenu(fileName = nameof(LevelEntryStateSo),
        menuName = nameof(ScriptableObject) + "/" + nameof(GameStates) + "/" + nameof(LevelEntryStateSo),
        order = 51)]
    public class LevelEntryStateSo : BaseGameStateSo
    {
        [SerializeField] private UnityObject _levelProvider;
        [SerializeField] private Scene _playerGeneratedPathScene;

        [SerializeField] private CurrentLevelSo _currentLevelSo;

        private readonly IAsyncSceneLoading _asyncSceneLoading = new AddressablesSceneLoading();


        private ILevelProvider LevelProvider => (ILevelProvider)_levelProvider;

        private void OnValidate() => 
            Inspector.ValidateOn<ILevelProvider>(ref _levelProvider);
        public override void Enter()
        {
            _currentLevelSo.Init();
            _asyncSceneLoading.LoadAsync(LevelProvider.Current.LocationScene);
            _asyncSceneLoading.LoadAsync(_playerGeneratedPathScene);
        }

        public override void Exit()
        {
            
        }
    }
}
