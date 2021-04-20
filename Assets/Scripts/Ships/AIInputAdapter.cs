using UnityEngine;

namespace Ships
{
    public class AIInputAdapter : Input
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

        public Vector2 GetDirection()
        {
            var viewportPoint = _camera.WorldToViewportPoint(_transform.position);

            if (Mathf.Approximately(viewportPoint.x, ClampMinValueViewportPoint))
                _currentDirectionX = 1;
            else if (Mathf.Approximately(viewportPoint.x, ClampMaxValueViewportPoint))
                _currentDirectionX = -1;

            return new Vector2(_currentDirectionX, 0);
        }
    }
}