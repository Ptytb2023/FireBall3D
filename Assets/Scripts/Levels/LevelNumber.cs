
namespace Levels
{
    public class LevelNumber : ILevelNumber
    {
        public int Value { get; set; }

        public LevelNumber() =>
         Value = 1;
    }
}
