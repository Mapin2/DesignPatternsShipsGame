using UnityEngine;

namespace Patterns.Mediator
{
    public class VehicleLight : MonoBehaviour
    {
        [SerializeField] private Light _light;
        private IVehicle _vehicle;

        public void Configure(IVehicle vehicle)
        {
            _vehicle = vehicle;
        }
        
        public void TurnOn()
        {
            _light.enabled = true;
        }

        public void TurnOff()
        {
            _light.enabled = false;
        }
    }
}
