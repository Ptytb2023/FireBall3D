namespace Factores
{
    public interface IFactory<out T>
    {
        public T Create();
    }
}