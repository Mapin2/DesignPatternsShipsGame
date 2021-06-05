using System;
using UnityEngine;

namespace Ships.Weapons
{
    public class WeaponController : MonoBehaviour
    {
        [SerializeField] private ProjectilesConfiguration _projectilesConfiguration;
        [SerializeField] private ProjectileId _defaultProjectileId;
        [SerializeField] private Transform _projectileSpawnPosition;
        [SerializeField] private float _fireRateInSeconds;
        
        private IShip _ship;
        private ProjectileId _activeProjectileId;
        private float _remainingSecondsToBeAbleToShoot;
        private ProjectileFactory _projectileFactory;

        private void Awake()
        {
            var instance = Instantiate(_projectilesConfiguration);
            _projectileFactory = new ProjectileFactory(instance);
        }

        public void Configure(IShip ship)
        {
            _ship = ship;
            _activeProjectileId = _defaultProjectileId;
        }

        private void Update()
        {
            _remainingSecondsToBeAbleToShoot -= Time.deltaTime;
        }

        public void TryShoot()
        {
            if (_remainingSecondsToBeAbleToShoot > 0) return;

            Shoot();
        }
        
        private void Shoot()
        {
            var projectile = _projectileFactory
                .Create(_activeProjectileId.Value,
                    _projectileSpawnPosition.position,
                    _projectileSpawnPosition.rotation);
            _remainingSecondsToBeAbleToShoot = _fireRateInSeconds;
        }
    }
}