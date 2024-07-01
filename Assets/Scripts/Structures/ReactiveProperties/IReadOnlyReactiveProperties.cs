using System;

namespace ReactiveProperties
{
    public interface IReadOnlyReactiveProperty<out T>
    {
        public T Value { get; }

        public void Subscribe(Action<T> valueChange);
        public void SubscribeAndUpdate(Action<T> valueChange);

        public void UnSubscribe(Action<T> valueChange);
    }
}
