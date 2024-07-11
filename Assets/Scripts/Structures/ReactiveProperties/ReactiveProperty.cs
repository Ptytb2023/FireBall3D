using System;
using System.Collections.Generic;
using ReactiveProperties;

namespace RelativeProperties
{
    internal class ReactiveProperty<T> : IReactivePropery<T>
    {
        public T Value { get; private set; }

        private List<Action<T>> _subscribers = new List<Action<T>>();

        public ReactiveProperty(T value)
            => Change(value);

        public void Change(T value)
        {
            Value = value;

            _subscribers.ForEach(subscribe => subscribe.Invoke(Value));
        }

        public void Subscribe(Action<T> valueChange)
        {
            _subscribers.Add(valueChange);
        }

        public void SubscribeAndUpdate(Action<T> valueChange)
        {
            valueChange?.Invoke(Value);
            Subscribe(valueChange);
        }

        public void UnSubscribe(Action<T> valueChange)
        {
            _subscribers.Remove(valueChange);
        }


    }
}
