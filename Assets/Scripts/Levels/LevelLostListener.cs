using Players;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Levels
{
	public class LevelLostListener : MonoBehaviour
	{
		[SerializeField] private Player _player;
		[SerializeField] private AssetReferenceGameObject _loseScreen;

		private void OnEnable() => 
			_player.Dead += OnPlayerDied;

		private void OnDisable() => 
			_player.Dead -= OnPlayerDied;

		private void OnPlayerDied() => 
			_loseScreen.InstantiateAsync();
	}
}