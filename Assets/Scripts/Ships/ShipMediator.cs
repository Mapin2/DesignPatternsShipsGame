using Input;
using Ships.CheckLimits;
using Ships.Weapons;
using UnityEngine;

namespace Ships
{
    [RequireComponent(typeof(MovementController))]
    [RequireComponent(typeof(WeaponController))]
    public class ShipMediator : MonoBehaviour, IShip
    {
        [SerializeField] private MovementController _movementController;
        [SerializeField] private WeaponController _weaponController;
        [SerializeField] private ShipId _shipId;
        
        public string Id => _shipId.Value;
        
        private IInput _input;
        
        public void Configure(IInput input, ICheckLimits checkLimits)
        {
            _input = input;
            _movementController.Configure(this, checkLimits);
            _weaponController.Configure(this);
        }

        private void Update()
        {
            var direction = _input.GetDirection();
            _movementController.Move(direction);
            TryShoot();
        }

        private void TryShoot()
        {
            if (_input.IsFireActionPressed())
            {
                _weaponController.TryShoot();
            }
        }
    }
}