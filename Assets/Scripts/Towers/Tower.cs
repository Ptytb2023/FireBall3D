using ReactiveProperties;
using RelativeProperties;
using System.Collections.Generic;
using System.Linq;

namespace Towers
{
    public class Tower
    {
        private readonly Queue<SegmentPlatform> _segments;
        private readonly ReactivePoperty<int> _countSegments;

        public IReadOnlyList<SegmentPlatform> Segments => _segments.ToList();
        public IReadOnlyReactiveProperty<int> CountSegments => _countSegments;


        public Tower(IEnumerable<SegmentPlatform> segemts) 
            : this(new Queue<SegmentPlatform>(segemts)) { }

        public Tower(Queue<SegmentPlatform> segments)
        {
            _segments = segments;
            _countSegments = new ReactivePoperty<int>(_segments.Count);
        }

        public SegmentPlatform GetTowerSegment()
        {
            var segment = _segments.Dequeue();

            _countSegments.Change(_segments.Count);

            return segment;
        }
    }
}
