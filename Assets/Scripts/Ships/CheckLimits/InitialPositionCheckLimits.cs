using System;
using UnityEngine;

namespace Ships.CheckLimits
{
    public class InitialPositionCheckLimits : ICheckLimits
    {
        private readonly Transform _transform;
        private readonly Vector3 _initialPosition;
        
        private readonly float _maxDistance;

        public InitialPositionCheckLimits(Transform transform, float maxDistance)
        {
            _transform = transform;
            _maxDistance = maxDistance;
            _initialPosition = _transform.position;
        }
        
        public void ClampFinalPosition()
        {
            var currentPosition = _transform.position;
            var finalPosition = currentPosition;
            var distance = Math.Abs(currentPosition.x - _initialPosition.x);

            if (distance <= _maxDistance) return;

            if (currentPosition.x > _initialPosition.x)
                finalPosition.x = _initialPosition.x + _maxDistance;
            else
                finalPosition.x = _initialPosition.x - _maxDistance;

            _transform.position = finalPosition;
        }
    }
}