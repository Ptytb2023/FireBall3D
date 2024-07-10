using SceneLoading;
using UnityEngine;
using GameStates.Base;

namespace GameStates.States
{
    [CreateAssetMenu(fileName = nameof(LevelLostState),
     menuName = nameof(ScriptableObject) + "/" + nameof(GameStates) + "/" + nameof(LevelLostState),
     order = 51)]
    public class LevelLostState : BaseGameStateSo
    {
        [SerializeField] private Scene _menu;

        private readonly IAsyncSceneLoading _sceneLoading = new AddressablesSceneLoading();

        public override void Enter() =>
            _sceneLoading.LoadAsync(_menu);

        public override void Exit() { } 
    }
}
