﻿using IoC;
using UnityEngine;
using Zenject;

namespace Levels
{
    [CreateAssetMenu(fileName = nameof(CurrentLevelSo),
      menuName = nameof(ScriptableObject) + "/" + nameof(Levels) + "/" + nameof(CurrentLevelSo),
      order = 51)]
    public class CurrentLevelSo : ScriptableObject, ILevelNumberProvider, ILevelProvider, ILevelChanging
    {
        [SerializeField] private LevelsStoreSo _strorage;

        private  ILevelNumber _levelNumber => Container.InstanceOf<ILevelNumber>();


        public Level Current => _strorage.Levles[_levelNumber.Value - 1];

        public int Value => _levelNumber.Value;

        public void StepToNextLevel()
        {
            int min = 1;
            int max = _strorage.Levles.Count;

            _levelNumber.Value = Mathf.Clamp(_levelNumber.Value + 1, min, max);
        }
    }
}
