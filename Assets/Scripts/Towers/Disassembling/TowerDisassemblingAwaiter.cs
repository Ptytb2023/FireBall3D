using System;
using System.Runtime.CompilerServices;

namespace Towers.Disassembling
{
    public struct TowerDisassemblingAwaiter : INotifyCompletion
    {

        private readonly TowerDisassembling _towerDisassembling;
        private Action _cotinauation;

        public TowerDisassemblingAwaiter(TowerDisassembling towerDisassembling)
        {
            _towerDisassembling = towerDisassembling;
            _cotinauation = null;
            IsCompleted = false;
        }

        public bool IsCompleted { get; private set; }

        public string GetResult() => string.Empty;

        public void OnCompleted(Action continuation)
        {
            _cotinauation = continuation;
            _towerDisassembling.Disassembling += OnTowerDisassembled;
        }

        private void OnTowerDisassembled()
        {
            _towerDisassembling.Disassembling -= OnTowerDisassembled;

            _cotinauation.Invoke();
            IsCompleted = true;
        }
    }
}
