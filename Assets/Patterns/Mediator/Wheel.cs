using UnityEngine;

namespace Patterns.Mediator
{
    public class Wheel : MonoBehaviour
    {
        private Vehicle _vehicle;

        public void Configure(Vehicle vehicle)
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
