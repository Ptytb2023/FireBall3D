using System.Threading.Tasks;
using UnityEngine;

namespace Towers.Generation
{
    public interface ITowerGeneration
    {
        public Task<Tower> CreatAsync(Transform tower);
    }
}