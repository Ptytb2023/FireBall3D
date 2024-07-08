using GameStates.Base;
using GameStates.States;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Buttons
{
    [RequireComponent(typeof(Button))]
    public class ResetButton : MonoBehaviour
    {
        [SerializeField] private GameStateMachineSo _stateMachine;

        private Button _button;

        private void Awake() =>
            _button = GetComponent<Button>();

        private void OnEnable() =>
            _button.onClick.AddListener(OnClickReset);


        private void OnDisable() =>
            _button.onClick.RemoveListener(OnClickReset);

        private void OnClickReset() =>
            _stateMachine.Enter<LevelLostState>();
    }
}
