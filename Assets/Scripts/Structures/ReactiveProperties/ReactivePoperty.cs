using ReactiveProperties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RelativeProperties
{
    internal class ReactivePoperty<T> : IReactivePropery<T>
    {
        public T Value { get; private set; }

        private List<Action<T>> _subscribers = new List<Action<T>>();

        public ReactivePoperty(T value)
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
