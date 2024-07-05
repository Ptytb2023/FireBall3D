using System;
using System.Collections;
using UnityEngine;


namespace Inputs
{
    public class PlayerInputHandler : MonoBehaviour, IInputPlayer
    {
        private InputPlayerAction _inputAction;

        private Coroutine _holdingCorutine;

        public event Action Begin;
        public event Action Ended;
        public event Action Hold;

        private void Awake() =>
            _inputAction = new InputPlayerAction();

        private void OnEnable()
        {
            _inputAction.Enable();
            _inputAction.Weapon.Shoot.performed += stx => OnPerfomed();
            _inputAction.Weapon.Shoot.canceled += stx => OnCanceled();
        }

        private void OnDisable()
        {
            _inputAction.Disable();
            _inputAction.Weapon.Shoot.performed -= stx => OnPerfomed();
            _inputAction.Weapon.Shoot.canceled -= stx => OnCanceled();
        }

        public void Enable() =>
            enabled = true;

        public void Disable() =>
            enabled = false;


        private void OnPerfomed()
        {
            _holdingCorutine = StartCoroutine(Holding());
            Begin?.Invoke();
        }

        private void OnCanceled()
        {
            StopCoroutine(_holdingCorutine);
            Ended?.Invoke();
        }

        private IEnumerator Holding()
        {
            while (enabled)
            {
                Hold?.Invoke();
                yield return null;
            }
        }
    }
}
