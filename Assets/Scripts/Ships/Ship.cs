using UnityEngine;

namespace Ships
{
    public class Ship : MonoBehaviour
    {
        [SerializeField] private float _speed;
        [SerializeField] private Joystick _joystick;
        
        private Transform _myTransform;
        private Camera _camera;
        private const float ClampMinValueViewportPoint = 0.03f;
        private const float ClampMaxValueViewportPoint = 0.97f;

        private void Awake()
        {
            _camera = Camera.main;
            _myTransform = transform;
        }

        private void Update()
        {
            var direction = GetDirection();
            Move(direction);
        }

        private void Move(Vector2 direction)
        {
            _myTransform.Translate(direction * (_speed * Time.deltaTime));
            ClampFinalPosition();
        }

        // This method prevents the ship from leaving the screen, also leaving a 3% margin on each side
        private void ClampFinalPosition()
        {
            var viewportPoint = _camera.WorldToViewportPoint(transform.position);
            viewportPoint.x = Mathf.Clamp(viewportPoint.x, ClampMinValueViewportPoint, ClampMaxValueViewportPoint);
            viewportPoint.y = Mathf.Clamp(viewportPoint.y, ClampMinValueViewportPoint, ClampMaxValueViewportPoint);
            _myTransform.position = _camera.ViewportToWorldPoint(viewportPoint);
        }

        private Vector2 GetDirection()
        {
            return new Vector2(_joystick.Horizontal, _joystick.Vertical);
            
            var horizontalDir = Input.GetAxis("Horizontal");
            var verticalDir = Input.GetAxis("Vertical");
            return new Vector2(horizontalDir, verticalDir);
        }
    }
}