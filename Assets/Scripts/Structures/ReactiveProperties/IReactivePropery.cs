namespace ReactiveProperties
{
    public interface IReactivePropery<T> : IReadOnlyReactiveProperty<T>
    {
        public void Change(T value);

    }
}
