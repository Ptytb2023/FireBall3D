using System.Collections.Generic;

namespace Towers
{
    public class Tower
    {
        private Queue<SegmentPlatform> _segments;

        public IEnumerable<SegmentPlatform> Segments => _segments;

        public int CountElements => _segments.Count;

        public Tower(IEnumerable<SegmentPlatform> segemts) : this(new Queue<SegmentPlatform>(segemts)) { }

        public Tower(Queue<SegmentPlatform> segments) =>
            _segments = segments;

        public SegmentPlatform GetTowerSegment() =>
            _segments.Dequeue();
    }
}
