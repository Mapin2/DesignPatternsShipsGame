using UnityEngine;

namespace Patterns.Mediator
{
    public class Brake : MonoBehaviour
    {
        private IVehicle _vehicle;

        public void Configure(IVehicle vehicle)
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