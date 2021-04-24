using UnityEngine;

namespace Patterns.Mediator
{
    public class Wheel : MonoBehaviour
    {
        private IVehicle _vehicle;

        public void Configure(IVehicle vehicle)
        {
            _vehicle = vehicle;
        }
        
        public void AddFriction()
        {
        }

        public void RemoveFriction()
        {
        }

        public void TurnLeft()
        {
        }

        public void TurnRight()
        {
        }
    }
}
