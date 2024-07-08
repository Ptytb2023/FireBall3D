using GameStates.Base;
using GameStates.States;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Menu.Buttons
{
    [RequireComponent(typeof(Button))]
    public class PlayButton : MonoBehaviour
    {
        [SerializeField] private GameStateMachineSo _stateMachine;
        private Button _button;

        private void Awake() =>
            _button = GetComponent<Button>();

        private void OnEnable() => 
            _button.onClick.AddListener(OnButtonClick);

        private void OnDisable() => 
            _button.onClick.RemoveListener(OnButtonClick);

        private void OnButtonClick() =>
            _stateMachine.Enter<LevelEntryStateSo>();
    }
}
