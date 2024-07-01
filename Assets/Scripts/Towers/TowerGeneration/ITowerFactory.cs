using UnityEngine;

namespace Towers.Generation
{
    public interface ITowerFactory
    {
        public Tower Creat(Transform tower);
    }
}