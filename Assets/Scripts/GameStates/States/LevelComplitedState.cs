using GameStates.Base;
using Levels;
using SceneLoading;
using System.Threading.Tasks;
using Tools;
using UnityEngine;
using UnityObject = UnityEngine.Object;


namespace Assets.Scripts.GameStates.States
{
    [CreateAssetMenu(fileName = nameof(LevelComplitedState),
        menuName = nameof(ScriptableObject) + "/" + nameof(GameStates) + "/" + nameof(LevelComplitedState),
        order = 51)]
    public class LevelComplitedState : BaseGameStateSo
    {
        [SerializeField] private Scene _menu;
        [SerializeField] private UnityObject _levelChanging;

        private ILevelChanging LevelChanging => (ILevelChanging)_levelChanging;

        private readonly IAsyncSceneLoading _sceneLoading = new AddressablesSceneLoading();

        private void OnValidate() =>
            Inspector.ValidateOn<ILevelChanging>(ref _levelChanging);

        public override async void Enter()
        {
            LevelChanging.StepToNextLevel();
            await _sceneLoading.LoadAsync(_menu);
        }

        public override async void Exit()
        {
            await Task.Delay(0);
        }
    }
}
