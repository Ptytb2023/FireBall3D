using System;
using System.Threading;
using System.Threading.Tasks;
using ReactiveProperties;
using Shooting.Pool;
using Towers;
using Towers.Disassembling;
using Towers.Effects;
using Towers.Generation;
using Tweening;
using UI.Towers;
using UnityEngine;

namespace Paths.Builders
{
	public class PathTowerBuilder : MonoBehaviour
	{
		[SerializeField] private Transform _towerRoot;
		
		[Header("Effects")]
		[SerializeField] private FastRotationTweenSo _spawnAnimation;

		[Header("Linked Components")]
		[SerializeField] private RestoreProjectilePoolTriget _projectileHitTrigger;
		[SerializeField] private TowerSegmentsCountLeftText _segmentsLeftText;
		[SerializeField] private TowerAudio _audio;

		private Action _unsubscribe;
		private TowerStructureSo _structure;
		
		public void Initialize(TowerStructureSo structure)
		{
			_structure = structure;
		}
		
		public async Task<TowerDisassembling> BuildAsync(ProjectilePool pool, CancellationToken cancellationToken)
		{
			_spawnAnimation.ApplyTo(_towerRoot);
			_projectileHitTrigger.Initialize(pool);

			TowerGenerator generator = new TowerGenerator(_structure);
			generator.SegmentCreated += _segmentsLeftText.UpdateTextValue;

			Tower tower = await generator.CreateAsync(_towerRoot, cancellationToken);
			TowerDisassembling disassembling = new TowerDisassembling(tower, _towerRoot);

			if (cancellationToken.IsCancellationRequested)
				return disassembling;
			
			SubscribeComponents(disassembling, tower, generator);

			return disassembling;
		}

		private void OnDisable() => 
			_unsubscribe?.Invoke();

		private void SubscribeComponents(TowerDisassembling disassembling, Tower tower, TowerGenerator generator)
		{
			_projectileHitTrigger.ProjectileReturned += disassembling.TryRemoveBottom;
			IReadOnlyReactiveProperty<int> segmentCount = tower.SegmentCount;

			segmentCount.Subscribe(_segmentsLeftText.UpdateTextValue);
			segmentCount.Subscribe(_audio.PlaySound);

			_unsubscribe = () =>
			{
				generator.Dispose();
				generator.SegmentCreated -= _segmentsLeftText.UpdateTextValue;
				_projectileHitTrigger.ProjectileReturned -= disassembling.TryRemoveBottom;
				segmentCount.UnSubscribe(_segmentsLeftText.UpdateTextValue);
				segmentCount.UnSubscribe(_audio.PlaySound);
			};
		}
	}
}