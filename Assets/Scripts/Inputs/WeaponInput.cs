using System;


namespace Inputs
{
    public class WeaponInput : IInputWeapon
    {
        private InputPlayerAction _inputAction;


        public WeaponInput(InputPlayerAction inputActions) =>
            _inputAction = inputActions;

        public event Action Begin;
        public event Action Ended;


        public void Enabel()
        {
            _inputAction.Enable();
            _inputAction.Weapon.Shoot.performed += stx => Begin?.Invoke();
            _inputAction.Weapon.Shoot.canceled += stx => Ended?.Invoke();
        }

        private void Disabel()
        {
            _inputAction.Disable();
            _inputAction.Weapon.Shoot.performed -= stx => Begin?.Invoke();
            _inputAction.Weapon.Shoot.canceled -= stx => Ended?.Invoke();
        }

    }
}
