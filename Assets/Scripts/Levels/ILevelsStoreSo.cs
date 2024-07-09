using System.Collections.Generic;

namespace Levels
{
    public interface ILevelsStoreSo
    {
        IReadOnlyList<Level> Levles { get; }
    }
}