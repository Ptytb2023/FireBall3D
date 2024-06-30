using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Pathes
{
    public class PathDrow : MonoBehaviour
    {
        [Header("Path")]
        [SerializeField] private Path _path;

        [Header("Points")]
        [SerializeField] private float _radiusPoint;

        [Header("Color")]
        [SerializeField] private Color _colorPoints;
        [SerializeField] private Color _colorLine;

        private void OnDrawGizmos()
        {
            Transform[] waypoints = GetAllPoints();
            DrowPoints(waypoints);
            DrawLineBetweenPoint(waypoints);
        }

        private void DrowPoints(IReadOnlyList<Transform> waypoints)
        {
            Gizmos.color = _colorPoints;
            foreach (Transform point in waypoints)
                Gizmos.DrawSphere(point.position, _radiusPoint);
        }

        private void DrawLineBetweenPoint(IReadOnlyList<Transform> waypoints)
        {
            Gizmos.color = _colorLine;

            for (int i = 1; i < waypoints.Count; i++)
                Gizmos.DrawLine(waypoints[i - 1].position, waypoints[i].position);
        }

        private Transform[] GetAllPoints()
        {
            Transform[] waypoints = Array.Empty<Transform>();

            foreach (var segmentPoints in _path.Pathes)
                waypoints = waypoints.Union(segmentPoints.Points).ToArray();

            return waypoints;
        }
    }
}
