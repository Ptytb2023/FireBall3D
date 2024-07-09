using Levels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tools;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityOnject = UnityEngine.Object;

namespace Menu.Levels
{
    public class MenuPlatformSequence : MonoBehaviour
    {
        [SerializeField] private LevelsColorSo _levelsColor;
        [SerializeField] private MenuLevelPlatfrom[] _levels = Array.Empty<MenuLevelPlatfrom>();
        [SerializeField] private AssetReferenceGameObject _levelMarket;

        [SerializeField] private UnityOnject _levelsNumberProvider;
        private ILevelNumberProvider LevelNumberProvider => (ILevelNumberProvider)_levelsNumberProvider;

        private int NextLevelNumber => LevelNumberProvider.Value;

        private void OnValidate()
        {
            Inspector.ValidateOn<ILevelNumberProvider>(ref _levelsNumberProvider);
        }

        private void Start()
        {
            Transform marketHolder = _levels[NextLevelNumber - 1].MarketHolder;
            _levelMarket.InstantiateAsync(marketHolder);

            for (int i = 0; i < NextLevelNumber - 1; i++)
                _levels[i].PaintNumber(_levelsColor.PassedLevels);

            for (int i = NextLevelNumber; i < _levels.Length; i++)
                _levels[i].PaintNumber(_levelsColor.NextLevels);

        }


    }
}
