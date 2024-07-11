using DataPersistence.Initialization;
using GameStates.Base;
using GameStates.States;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;

namespace Infrastructure
{
    public class Bootstrap : MonoBehaviour
    {
        [SerializeField] private AsyncInitialization[] _initializations;
        [SerializeField] private GameStateMachineSo _stateMachine;

        private async void OnEnable()
        {
            var instializtions = _initializations.Select(x => x.InitializeAsync());

            await Task.WhenAll(instializtions);

            _stateMachine.Enter<MenuEntryStateSo>();
        }
    }
}