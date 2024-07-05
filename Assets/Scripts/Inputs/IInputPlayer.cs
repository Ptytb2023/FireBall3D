using System;


namespace Inputs
{
    public interface IInputPlayer
    {

        public event Action Begin;
        public event Action Ended;
        public event Action Hold;
      
    }
}