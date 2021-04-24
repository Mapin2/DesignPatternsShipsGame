using UnityEngine;

namespace Patterns.Mediator
{
    public class SteeringWheel : MonoBehaviour
    {
        private Vehicle _vehicle;

        public void Configure(Vehicle vehicle)
        {
            _vehicle = vehicle;
        }

        private void Update()
        {
            if (UnityEngine.Input.GetButtonDown("Left"))
            {
                _vehicle.LeftPressed();
            }
            else if (UnityEngine.Input.GetButtonDown("Right"))
            {
                _vehicle.RightPressed();
            }
        }
    }
}