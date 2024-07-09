using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataPersistence.Initialization;
using GameStates.Base;
using GameStates.States;
using UnityEngine;

namespace Infrastructure
{
	public class Bootstrap : MonoBehaviour
	{
		[SerializeField] private AsyncInitialization[] _initializations;
		[SerializeField] private GameStateMachineSo _stateMachine;

		private async void OnEnable()
		{
			IEnumerable<Task> initializations = _initializations.Select(x => x.InitializeAsync());

			await Task.WhenAll(initializations);
			
			_stateMachine.Enter<MenuEntryStateSo>();
		}
	}
}