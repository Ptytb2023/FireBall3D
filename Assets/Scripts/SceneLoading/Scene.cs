using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SceneLoading
{
    [Serializable]
    public struct Scene
    {
        public Scene(string name, LoadSceneMode loadMode, UnloadSceneOptions unloadMode) : this()
        {
            Name = name;
            LoadMode = loadMode;
            UnloadMode = unloadMode;
        }

        [field: SerializeField] public string Name { get; private set; }
        [field: SerializeField] public LoadSceneMode LoadMode { get; private set; }
        [field: SerializeField] public UnloadSceneOptions UnloadMode { get; private set; }

    }
}
