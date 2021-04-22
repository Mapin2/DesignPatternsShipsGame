using UnityEngine;

namespace Ships.CheckLimits
{
    public class ViewportCheckLimits : ICheckLimits
    { 
        private readonly Transform _transform;
        private readonly Camera _camera;
        
        private const float ClampMinValueViewportPoint = 0.03f;
        private const float ClampMaxValueViewportPoint = 0.97f;

        public ViewportCheckLimits(Transform transform, Camera camera)
        {
            _transform = transform;
            _camera = camera;
        }

        public void ClampFinalPosition()
        {
            var viewportPoint = _camera.WorldToViewportPoint(_transform.position);
            viewportPoint.x = Mathf.Clamp(viewportPoint.x, ClampMinValueViewportPoint, ClampMaxValueViewportPoint);
            viewportPoint.y = Mathf.Clamp(viewportPoint.y, ClampMinValueViewportPoint, ClampMaxValueViewportPoint);
            _transform.position = _camera.ViewportToWorldPoint(viewportPoint);
        }
    }
}