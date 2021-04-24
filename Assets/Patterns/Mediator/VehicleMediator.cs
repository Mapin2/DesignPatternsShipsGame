using System.Net.Http.Headers;
using UnityEngine;

namespace Patterns.Mediator
{
    public class VehicleMediator : MonoBehaviour, Vehicle
    {
        [SerializeField] private Wheel[] _wheels;
        [SerializeField] private VehicleLight[] _brakeLights;
        [SerializeField] private SteeringWheel _steeringWheel;
        [SerializeField] private Brake _brake;
        [SerializeField] private Autopilot _autopilot;

        private void Configure()
        {
            foreach (var wheel in _wheels)
            {
                wheel.Configure(this);
            }
            foreach (var brakeLight in _brakeLights)
            {
                brakeLight.Configure(this);
            }
            _steeringWheel.Configure(this);
            _brake.Configure(this);
            _autopilot.Configure(this);
        }

        public void BrakePressed()
        {
            foreach (var wheel in _wheels)
            {
                wheel.AddFriction();
            }

            foreach (var brakeLight in _brakeLights)
            {
                brakeLight.TurnOn();
            }
        }

        public void BrakeReleased()
        {
            foreach (var wheel in _wheels)
            {
                wheel.RemoveFriction();
            }

            foreach (var brakeLight in _brakeLights)
            {
                brakeLight.TurnOff();
            }
        }

        public void LeftPressed()
        {
            foreach (var wheel in _wheels)
            {
                wheel.TurnLeft();
            }
        }

        public void RightPressed()
        {
            foreach (var wheel in _wheels)
            {
                wheel.TurnRight();
            }
        }

        public void ObstacleDetected()
        {
            BrakePressed();
        }
    }
}