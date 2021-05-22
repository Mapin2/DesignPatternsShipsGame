using System.Linq;
using UnityEngine;

namespace Ships.Weapons
{
    public class WeaponController : MonoBehaviour
    {
        [SerializeField] private float _fireRateInSeconds;
        [SerializeField] private Projectile[] _projectilePrefabs;
        [SerializeField] private Transform _projectileSpawnPosition;
        
        private IShip _ship;
        private string _activeProjectileId;
        private float _remainingSecondsToBeAbleToShoot;
        
        public void Configure(IShip ship)
        {
            _ship = ship;
            _activeProjectileId = "Projectile1";
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
            var prefab = _projectilePrefabs.First(projectile => projectile.Id.Equals(_activeProjectileId));
            _remainingSecondsToBeAbleToShoot = _fireRateInSeconds;
            Instantiate(prefab, _projectileSpawnPosition.position, _projectileSpawnPosition.rotation);
        }
    }
}