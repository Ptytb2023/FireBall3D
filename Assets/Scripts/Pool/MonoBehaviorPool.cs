using Factores;
using UnityEngine;

namespace Pool
{
    public class MonoBehaviorPool<T> : MonoBehaviour, IPool<T> where T : Component
    {
        [SerializeField] private Transform _root;

        private PoolComponent<T> _pool;


        public void Init(IFactory<T> factory, int capacity)
        {
            _pool = new PoolComponent<T>(_root, factory, capacity);
            Prewarm();
        }


        public void Prewarm() => 
            _pool.Prewarm();

        public T Request() =>
            _pool.Request();

        public void Return(T member) => 
            _pool.Return(member);
    }
}