using System;
using UnityEngine;

namespace Ships.Weapons.Projectiles
{
    public class SinusoidalProjectile : Projectile
    {
        [SerializeField] private float _speed;
        [SerializeField] private float _amplitude;
        [SerializeField] private float _frequency;

        private Vector3 _currentPosition;
        private float _currentTime;

        protected override void DoStart()
        {
            _currentTime = 0f;
            _currentPosition = _myTransform.position;
        }

        protected override void DoMove()
        {
            _currentPosition += transform.up * (_speed * Time.fixedDeltaTime);
            
            var horizontalPosition = _myTransform.right * (_amplitude * Mathf.Sin(_currentTime * _frequency));
            
            _rigidbody2D.MovePosition(_currentPosition + horizontalPosition);
            
            _currentTime += Time.fixedDeltaTime;
        }

        protected override void DoDestory()
        {
            throw new NotImplementedException();
        }
    }
}