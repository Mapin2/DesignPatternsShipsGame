using UnityEngine;

namespace Input
{
    public class AIInputAdapter : IInput
    {
        private float _currentDirectionX;

        private readonly Camera _camera;
        private readonly Transform _transform;

        private const float ClampMinValueViewportPoint = 0.05f;
        private const float ClampMaxValueViewportPoint = 0.95f;

        public AIInputAdapter(Transform transform, Camera camera)
        {
            _camera = camera;
            _currentDirectionX = 1;
            _transform = transform;
        }

        // BUG: This GetDirection() method wont work if the CheckLimitStrategy used is the InitialPositionCheckLimits for an AIInputAdapter since it's working with viewport
        // BUG: In 16:9 will work but probably break in other aspect ratios / resolutions
        public Vector2 GetDirection()
        {
            var viewportPoint = _camera.WorldToViewportPoint(_transform.position);

            if (viewportPoint.x < ClampMinValueViewportPoint)
                _currentDirectionX = _transform.right.x;
            else if (viewportPoint.x > ClampMaxValueViewportPoint)
                _currentDirectionX = -_transform.right.x;

            return new Vector2(_currentDirectionX, +1);
        }

        public bool IsFireActionPressed()
        {
            return Random.Range(0, 100) < 20;
        }
    }
}