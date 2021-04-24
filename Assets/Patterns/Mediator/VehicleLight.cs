using UnityEngine;

namespace Patterns.Mediator
{
    public class VehicleLight : MonoBehaviour
    {
        [SerializeField] private Light _light;
        private Vehicle _vehicle;

        public void Configure(Vehicle vehicle)
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
