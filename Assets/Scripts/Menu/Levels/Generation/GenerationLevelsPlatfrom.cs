using Levels;
using System.Collections.Generic;
using System.Drawing;

namespace Menu.Levels.Generation
{
    public class GenerationLevelsPlatfrom
    {
        private MenuLevelPlatfrom _prefab;
        private ILevelNumberProvider _numberProvider;
        private LevelsColorSo _levelsColorsSo;

        public GenerationLevelsPlatfrom(MenuLevelPlatfrom prefab, ILevelNumberProvider numberProvider, LevelsColorSo levelsColorsSo)
        {
            _prefab = prefab;
            _numberProvider = numberProvider;
            _levelsColorsSo = levelsColorsSo;
        }

        public IReadOnlyList<MenuLevelPlatfrom> Creat(int count)
        {
            List<MenuLevelPlatfrom> platfroms = new List<MenuLevelPlatfrom>();

            for (int i = 0; i < count; i++)
            {

            }

            return null;
        }


    }
}
