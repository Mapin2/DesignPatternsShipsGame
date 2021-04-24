using UnityEngine;

namespace Patterns.Mediator
{
    public class Brake : MonoBehaviour
    {
        private Vehicle _vehicle;

        public void Configure(Vehicle vehicle)
        {
            _vehicle = vehicle;
        }

        private void Update()
        {
            if (UnityEngine.Input.GetButtonDown("Break"))
            {
                _vehicle.BrakePressed();
            }
            else if (UnityEngine.Input.GetButtonUp("Break"))
            {
                _vehicle.BrakeReleased();
            }
        }
    }
}