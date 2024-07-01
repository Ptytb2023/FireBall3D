using System;
using System.Collections.Generic;
using UnityEngine;

using Factores;

namespace Pool
{
    public class PoolComponent<T> : IPool<T> where T : Component
    {
        private readonly Stack<T> _availableMembers = new Stack<T>();
        private readonly Transform _root;
        private readonly IFactory<T> _factory;

        private int _capacity = 4;
        public PoolComponent(Transform root, IFactory<T> factory)
        {
            _root = root;
            _factory = factory;
        }

        public PoolComponent(Transform root, IFactory<T> factory, int capacity)
            : this(root, factory) =>
            _capacity = capacity;



        public void Prewarm()
        {
            for (int i = 0; i < _capacity; i++)
            {
                T member = _factory.Create();
                Setup(member);
            }
        }

        public T Request()
        {
            if (_availableMembers.Count <= 0)
                Prewarm();

            return _availableMembers.Pop();
        }

        public void Return(T member)
        {
            if (member is null)
                throw new ArgumentNullException();

            Setup(member);
        }

        private void Setup(T member)
        {
            member.gameObject.SetActive(false);
            member.transform.parent = _root;

            _availableMembers.Push(member);
        }
    }
}
