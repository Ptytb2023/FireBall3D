using System;
using System.Threading.Tasks;
using UnityEngine;

namespace Generation
{
    [CreateAssetMenu(
        fileName = nameof(TowerFactorySo),
        menuName = nameof(ScriptableObject) + "/" + nameof(Tower) + "/" + nameof(TowerFactorySo),
        order = 51)]
    public class TowerFactorySo : ScriptableObject, IAsyncTowerFactory
    {
        public Task<Tower> CreatAsync(Transform postion)
        {
            return null;
        }
    }

}