using System;

namespace Towers.Generation
{
    public interface ITowerSwichSegmentCallback
    {
        public event Action<int> SwichSegment;
    }
}
