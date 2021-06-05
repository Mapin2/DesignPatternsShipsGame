using System.Collections;
using UnityEngine;

namespace Ships.Weapons.Projectiles
{
    public class CurveProjectile : Projectile
    {
        [SerializeField] private Rigidbody2D _rigidbody2D;
        [SerializeField] private float _speed;
        [SerializeField] private float _projectileLifeInSeconds;
        [SerializeField] private AnimationCurve _horizontalPosition;
        
        private Transform _myTransform;
        private Vector3 _currentPosition;
        private float _currentTime;

        private void Start()
        {
            _myTransform = transform;
            _currentTime = 0f;
            _currentPosition = _myTransform.position;
            StartCoroutine(DestroyIn(_projectileLifeInSeconds));
        }

        private void FixedUpdate()
        {
            _currentPosition += transform.up * (_speed * Time.fixedDeltaTime);
            var horizontalPosition = _myTransform.right * _horizontalPosition.Evaluate(_currentTime);
            _rigidbody2D.MovePosition(_currentPosition + horizontalPosition);
            _currentTime += Time.fixedDeltaTime;
        }

        private IEnumerator DestroyIn(float seconds)
        {
            yield return new WaitForSeconds(seconds);
            Destroy(gameObject);
        }
    }
}