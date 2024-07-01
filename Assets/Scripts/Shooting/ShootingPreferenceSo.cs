using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Shooting
{
    [CreateAssetMenu(fileName = nameof(ShootingPreferenceSo),
        menuName = nameof(ScriptableObject) + "/" + nameof(Shooting) + "/" + nameof(ShootingPreferenceSo),
        order = 51)]
    public class ShootingPreferenceSo : ScriptableObject
    {
        [SerializeField] private Projectile _ProjectilePrfeb;
        [SerializeField][Min(0)] private float _speedBullet;
        [SerializeField][Min(0)] private float _fireRate;

        public Projectile Projectile => _ProjectilePrfeb;
        public float speedBullet => _speedBullet;
        public float FireRate=>_fireRate;

    }
}
