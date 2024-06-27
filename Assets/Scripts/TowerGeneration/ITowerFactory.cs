using System.Threading.Tasks;
using UnityEngine;

namespace Generation
{
    public interface ITowerFactory
    {
        public Tower Creat(Transform tower);
    }
}