using System.Collections.Generic;

namespace Generation
{
    public class Tower
    {
        private Queue<SegmentPlatform> _segments;

        public IEnumerable<SegmentPlatform> Segments => _segments;

        public Tower(IEnumerable<SegmentPlatform> segemts) : this(new Queue<SegmentPlatform>(segemts)) { }

        public Tower(Queue<SegmentPlatform> segments) =>
            _segments = segments;
    }
}
