using Players;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Levels
{
    public class LevelLostLisener : MonoBehaviour
    {
        [SerializeField] private Player _player;
        [SerializeField] private AssetReferenceGameObject _loseScreen;

        private void OnEnable() =>
            _player.Dead += OnDeadPlayer;

        private void OnDisable() =>
            _player.Dead -= OnDeadPlayer;

        private void OnDeadPlayer() =>
            _loseScreen.InstantiateAsync();
    }

}
