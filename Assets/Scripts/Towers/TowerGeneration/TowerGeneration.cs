using System;
using UnityEngine;

using UnityObject = UnityEngine.Object;
using System.Threading.Tasks;
using System.Collections.Generic;
using Towers.Strucure;
using System.Threading;


namespace Towers.Generation
{
    public class TowerGeneration : ITowerGeneration, ITowerCallbackContects, IDisposable
    {
        private readonly TowerStructuresSo _strucures;

        private readonly CancellationTokenSource _cancellationTokenSource;
        private readonly CancellationToken _cancellationToken = new CancellationToken();

        public event Action<int> CreatSegment;

        public TowerGeneration(TowerStructuresSo towerStrucuresSo)
        {
            _strucures = towerStrucuresSo;

            _cancellationTokenSource = new CancellationTokenSource();
            _cancellationToken = _cancellationTokenSource.Token;
        }

        public async Task<Tower> CreatAsync(Transform parent) =>
            await CreatAsync(parent, _cancellationToken);

        public void Dispose()
        {
            _cancellationTokenSource.Cancel();
            _cancellationTokenSource.Dispose();
        }

        public async Task<Tower> CreatAsync(Transform tower, CancellationToken cancellationToken)
        {
            Vector3 postionSpawn = tower.position;
            int countSegment = _strucures.SegmentCount;

            float delay = _strucures.SpawnTimeSegmentMillisecond;

            Queue<SegmentPlatform> segments = new Queue<SegmentPlatform>(countSegment);

            for (int i = 0; i < countSegment; i++)
            {
                SegmentPlatform platform = CreatPlatform(tower, postionSpawn, i);
                platform.gameObject.SetActive(true);

                postionSpawn = NextPostionAfter(postionSpawn, platform);

                segments.Enqueue(platform);
                CreatSegment?.Invoke(i + 1);

                await ApllayDelay(delay, cancellationToken);

                if (cancellationToken.IsCancellationRequested)
                    break;
            }


            return new Tower(segments);
        }

        private async Task ApllayDelay(float second, CancellationToken cancellationToken)
        {
            TimeSpan delay = TimeSpan.FromSeconds(second);

            await Task.Delay(delay, cancellationToken);

            if (cancellationToken.IsCancellationRequested)
                return;
        }

        private SegmentPlatform CreatPlatform(Transform tower, Vector3 postionSpawn, int nuberOfInstancei)
        {
            SegmentPlatform prefab = _strucures.SegmentPrefab;

            var platform = UnityObject.Instantiate(prefab, postionSpawn, Quaternion.identity, tower);
            platform.SetMaterial(_strucures.GetMaterial(nuberOfInstancei));

            return platform;
        }

        private Vector3 NextPostionAfter(Vector3 currentPostion, SegmentPlatform ToPlatform)
        {
            float segmentHight = ToPlatform.transform.localScale.y;

            return currentPostion + segmentHight * Vector3.up;

        }
    }
}