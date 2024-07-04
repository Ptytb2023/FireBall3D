using System.Threading.Tasks;
using UnityEngine;

namespace Tweening
{
    public interface IAwaitableTweenAnimation
    {
        public Task ApplyTo(Transform transform);
    }
}
