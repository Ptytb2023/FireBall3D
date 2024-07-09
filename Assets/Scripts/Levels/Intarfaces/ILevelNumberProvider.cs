using Menu.Levels;

namespace Levels
{
    public interface ILevelProvider
    {
        public Level Current { get; }
    }
    public interface ILevelNumberProvider
    {
        public int Value { get; }
    }
}