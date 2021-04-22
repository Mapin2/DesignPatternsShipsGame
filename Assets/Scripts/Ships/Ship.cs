using Input;
using Ships.CheckLimits;
using Ships.Weapons;
using UnityEngine;

namespace Ships
{
    public class Ship : MonoBehaviour
    {
        [SerializeField] private float _speed;
        [SerializeField] private float _fireRateInSeconds;
        [SerializeField] private Projectile _projectilePrefab;
        [SerializeField] private Transform _projectileSpawnPosition;
        
        private IInput _input;
        private ICheckLimits _checkLimits;
        private Transform _myTransform;
        private float _remainingSecondsToBeAbleToShoot;
        
        private void Awake()
        {
            _myTransform = transform;
        }

        public void Configure(Input.IInput input, ICheckLimits checkLimits)
        {
            _input = input;
            _checkLimits = checkLimits;
        }

        private void Update()
        {
            var direction = GetDirection();
            Move(direction);
            TryShoot();
        }

        private void Move(Vector2 direction)
        {
            _myTransform.Translate(direction * (_speed * Time.deltaTime));
            _checkLimits.ClampFinalPosition();
        }

        private Vector2 GetDirection()
        {
            return _input.GetDirection();
        }
        
        private void TryShoot()
        {
            _remainingSecondsToBeAbleToShoot -= Time.deltaTime;
            
            if (_remainingSecondsToBeAbleToShoot > 0) return;

            if (_input.IsFireActionPressed())
            {
                Shoot();
            }
        }

        private void Shoot()
        {
            _remainingSecondsToBeAbleToShoot = _fireRateInSeconds;
            Instantiate(_projectilePrefab, _projectileSpawnPosition.position, _projectileSpawnPosition.rotation);
        }
    }
}