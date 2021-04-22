using UnityEngine;

namespace Input
{
    public class AIInputAdapter : IInput
    {
        private int _currentDirectionX;

        private readonly Camera _camera;
        private readonly Transform _transform;

        private const float ClampMinValueViewportPoint = 0.03f;
        private const float ClampMaxValueViewportPoint = 0.97f;

        public AIInputAdapter(Transform transform, Camera camera)
        {
            _camera = camera;
            _currentDirectionX = 1;
            _transform = transform;
        }

        // BUG: This GetDirection() method wont work if the CheckLimitStrategy used is the InitialPositionCheckLimits for an AIInputAdapter since it's working with viewport
        public Vector2 GetDirection()
        {
            var viewportPoint = _camera.WorldToViewportPoint(_transform.position);

            if (Mathf.Approximately(viewportPoint.x, ClampMinValueViewportPoint))
                _currentDirectionX = 1;
            else if (Mathf.Approximately(viewportPoint.x, ClampMaxValueViewportPoint))
                _currentDirectionX = -1;

            return new Vector2(_currentDirectionX, 0);
        }

        public bool IsFireActionPressed()
        {
            return Random.Range(0, 100) < 20;
        }
    }
}