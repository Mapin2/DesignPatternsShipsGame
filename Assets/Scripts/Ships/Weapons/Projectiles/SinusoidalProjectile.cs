using System;
using System.Collections;
using UnityEngine;

namespace Ships.Weapons.Projectiles
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class SinusoidalProjectile : Projectile
    {
        [SerializeField] private Rigidbody2D _rigidbody2D;
        [SerializeField] private float _speed;
        [SerializeField] private float _projectileLifeInSeconds;
        [SerializeField] private float _amplitude;
        [SerializeField] private float _frequency;

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
            var horizontalPosition = _myTransform.right * (_amplitude * Mathf.Sin(_currentTime * _frequency));
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