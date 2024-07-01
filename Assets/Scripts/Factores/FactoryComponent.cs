using Factores;
using UnityEngine;

using UnityObject = UnityEngine.Object;

namespace Factores
{
    public class FactoryComponent<T> : IFactory<T> where T : Component
    {
        private readonly T _componentPrefb;

        public FactoryComponent(T componentPrefb) =>
            _componentPrefb = componentPrefb;


        public T Create() =>
            UnityObject.Instantiate(_componentPrefb);

        public TSource Create<TSource>(TSource source) where TSource : UnityObject =>
            UnityObject.Instantiate(source);
    }
}
