using System;


namespace Inputs
{
    public interface IInputWeapon
    {

        public event Action Begin;
        public event Action Ended;
        public event Action Hold;
      
    }
}