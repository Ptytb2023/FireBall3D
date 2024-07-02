using System;

namespace Towers.Generation
{
    public interface ITowerCallbackContects
    {
        public event Action<int> CreatSegment;
    }
}
