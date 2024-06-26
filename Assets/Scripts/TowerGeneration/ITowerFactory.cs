using System.Threading.Tasks;
using UnityEngine;

namespace Generation
{
    public interface IAsyncTowerFactory
    {
        public Task<Tower> CreatAsync(Transform postion);
    }
}