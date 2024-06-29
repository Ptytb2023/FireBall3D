using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityObject = UnityEngine.Object;

namespace Shooting
{
    public class Weapon
    {
        private readonly Transform _shootPoint;
        private readonly Projectile _projectilePrefab;
        private readonly float _speedBollet;

        public Weapon(Transform shootPoint, Projectile projectilePrefab, float speedBollet)
        {
            _shootPoint = shootPoint;
            _projectilePrefab = projectilePrefab;
            _speedBollet = speedBollet;
        }


        public void Shoot() =>
            UnityObject.Instantiate(_projectilePrefab).
            Shoot(_shootPoint.position, _shootPoint.forward, _speedBollet);
    }
}
