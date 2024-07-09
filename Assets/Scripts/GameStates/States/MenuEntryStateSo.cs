using GameStates.Base;
using SceneLoading;
using UnityEngine;

namespace GameStates.States
{
	[CreateAssetMenu(fileName = "MenuEntryState", menuName = "ScriptableObjects/Game/States/MenuEntryState")]
	public class MenuEntryStateSo : BaseGameStateSo
	{
		[SerializeField] private Scene _menu;

		private readonly IAsyncSceneLoading _sceneLoading = new AddressablesSceneLoading();
		
		public override void Enter()
		{
			_sceneLoading.LoadAsync(_menu);
		}

		public override void Exit()
		{
		}
	}
}