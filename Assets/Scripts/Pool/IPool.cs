using UnityEngine;

namespace Pool
{
    public interface IPool<T>
    {
        public void Prewarm();
        public T Request();
        public void Return(T member);
    }
}
