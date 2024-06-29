using System.Collections;
using UnityEngine;

namespace Coroutines
{
    public class CoroutinesExecutor
    {
        private readonly MonoBehaviour _executor;

        public CoroutinesExecutor(MonoBehaviour executor)
        {
            _executor = executor;
        }

        public Coroutine Start(IEnumerator coroutine) =>
            _executor.StartCoroutine(coroutine);

        public void Stop(Coroutine coroutine) =>
            _executor.StopCoroutine(coroutine);
    }
}
