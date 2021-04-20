using UnityEngine;

namespace Ships
{
    public class Ship : MonoBehaviour
    {
        [SerializeField] private float _speed;
        private Input _input;
        
        private Transform _myTransform;
        private ICheckLimits _checkLimits;
        

        private void Awake()
        {
            _myTransform = transform;
        }

        public void Configure(Input input, ICheckLimits checkLimits)
        {
            _input = input;
            _checkLimits = checkLimits;
        }

        private void Update()
        {
            var direction = GetDirection();
            Move(direction);
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
    }
}