using Ships.CheckLimits;
using UnityEngine;

namespace Ships
{
    public class MovementController : MonoBehaviour
    {
        [SerializeField] private Vector2 _speed;
        
        private IShip _ship;
        private ICheckLimits _checkLimits;
        private Transform _myTransform;

        public void Configure(IShip ship, ICheckLimits checkLimits)
        {
            _ship = ship;
            _checkLimits = checkLimits;
        }
                
        private void Awake()
        {
            _myTransform = transform;
        }

        public void Move(Vector2 direction)
        {
            _myTransform.Translate(direction * (_speed * Time.deltaTime));
            _checkLimits.ClampFinalPosition();
        }
    }
}